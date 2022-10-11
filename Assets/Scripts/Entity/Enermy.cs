using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour, IBaseEntity
{
    public BaseData.PlayerDataManager playerData;

    private Rigidbody2D _body;

    public Transform playerTransform;

    public float BaseSpeed { get; set; } = 15;
    public float SmoothTime { get; set; } = 0.04f;

    private Vector3 velocitySmoothing;

    GameObject Player;

    float newPositionX;
    float newPositionY;

    Vector3 targetPosition;

    private Vector3 moveDir;
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
        targetPosition = Player.transform.position;
        Debug.Log("targetPosition: " + targetPosition);
    }
    // Update is called once per frame
    void Update()
    {
        //targetPosition = Player.transform.position;
        targetPosition = Player.transform.position;
        Debug.Log("targetPosition: " + targetPosition);
        Movement();
    }
    public void Movement()
    {
        while (gameObject.transform.position.x != targetPosition.x)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y, 0);
        }

        while (transform.position.y != targetPosition.y)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.1f, 0);
        }

        Debug.Log("newPosition: " + gameObject.transform.position);
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    collision.gameObject.SetActive(false);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.Instance.PlayAudioOneShot((AudioClip)Resources.Load("Audios/KillSound"), 0.1f);
        //collision.gameObject.SetActive(false);
    }
}
