using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    public BaseData.PlayerDataManager playerData;

    private Rigidbody2D _body;

    public Transform playerTransform;

    public float BaseSpeed { get; set; } = 5f;
    public float SmoothTime { get; set; } = 0.04f;


    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        playerTransform.position = getPlayerTransform().position;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        playerTransform.position = getPlayerTransform().position;
        Debug.Log("playerPos: " + playerTransform.position);

        Vector3 newPos = Vector3.MoveTowards(transform.position, playerTransform.position, BaseSpeed * Time.deltaTime);
        _body.MovePosition(newPos);
        transform.LookAt(playerTransform);

        
        Debug.Log("newPos: " + newPos);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        Debug.Log("Ouchhhh!");
        //collision.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.Instance.PlayAudioOneShot((AudioClip)Resources.Load("Audios/KillSound"), 0.1f);
        //collision.gameObject.SetActive(false);
    }

    private Transform getPlayerTransform()
    {
        return GameObject.FindGameObjectWithTag("Player").gameObject.transform;
    }
}
