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

    [SerializeField]
    GameObject enermy;

    private Vector3 moveDir;
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Movement()
    {
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.Instance.PlayAudioOneShot((AudioClip)Resources.Load("Audios/KillSound"), 0.1f);
        collision.gameObject.SetActive(false);
    }
}
