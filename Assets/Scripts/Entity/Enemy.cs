using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    GameObject player;
    float MoveUnitsPerSecond = 1f;
    //float distance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        if(player != null)
        {
            float step = MoveUnitsPerSecond * Time.deltaTime;
            Vector3 point = new Vector3(player.transform.position.x, player.transform.position.y, -Camera.main.transform.position.z);
            transform.position = Vector2.MoveTowards(transform.position, point, step);

            if (player.gameObject.GetComponent<Player>().SafeDistance >= Vector3.Distance(this.transform.position, player.transform.position)) {
                tag = "DangerEnemy";
            } else
            {
                tag = "Enemy";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Collision exit");
        if(collision.gameObject.tag == "Player")
        {
            MoveUnitsPerSecond = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collision enter");
        if(collision.gameObject.tag == "Player")
        {
            MoveUnitsPerSecond = 0f;
        }
        if(collision.gameObject.tag.Contains("Weapon"))
        {
            gameObject.SetActive(false);
        }
        
    }
}
