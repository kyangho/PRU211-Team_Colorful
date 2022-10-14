using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IBaseEntity
{
    public BaseData.PlayerDataManager playerData;

    private Rigidbody2D _body;

    public Transform playerTransform;   
    
    public float BaseSpeed { get; set; } = 15;
    public float SmoothTime { get; set; } = 0.04f;

    private Vector3 velocitySmoothing;

    public FloatingJoystick joystick;
    private State PlayerState { get; set; } = State.IDLE;

    private Vector3 moveDir;
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        joystick = GameObject.FindGameObjectWithTag("InputControl").GetComponent<FloatingJoystick>();
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        switch (PlayerState)
        {
            case State.MOVEMENT:
                break;
            case State.IDLE:
                Idle();
                break;
        }
        
    }
    public void Movement()
    {
        bool isMoving = false;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            isMoving = true;
            _body.velocity = Vector3.SmoothDamp(_body.velocity, Vector3.left * BaseSpeed, ref velocitySmoothing, SmoothTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            isMoving = true;
            _body.velocity = Vector3.SmoothDamp(_body.velocity, Vector3.right * BaseSpeed, ref velocitySmoothing, SmoothTime);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            isMoving = true;
            _body.velocity = Vector3.SmoothDamp(_body.velocity, Vector3.up * BaseSpeed, ref velocitySmoothing, SmoothTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            isMoving = true;
            _body.velocity = Vector3.SmoothDamp(_body.velocity, Vector3.down * BaseSpeed, ref velocitySmoothing, SmoothTime);
        }

        if (joystick && joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            isMoving = true;
            moveDir = new Vector2(joystick.Horizontal, joystick.Vertical);
            _body.velocity = Vector3.SmoothDamp(_body.velocity, moveDir * BaseSpeed, ref velocitySmoothing, SmoothTime);
        }
        if (isMoving)
        {
            PlayerState = State.MOVEMENT;
        } else
        {
            PlayerState = State.IDLE;
        }
    }

    public void Idle()
    {
        _body.velocity = Vector3.zero;
    }
    enum State
    {
        IDLE = 0,
        MOVEMENT = 1,
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.Instance.PlayAudioOneShot((AudioClip) Resources.Load("Audios/KillSound"), 0.1f);
        if (collision.tag.ToLower().Equals("enemy"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
