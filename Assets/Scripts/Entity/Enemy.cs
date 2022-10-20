using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    GameObject player;
    float MoveUnitsPerSecond = 1f;
    [SerializeField]
    float atk = 10f;
    [SerializeField]
    float attackRange = 2f;
    [SerializeField]
    float cdTime = 2000f;
    [SerializeField]
    float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = cdTime;
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
            float distanceToPlayer = Vector3.Distance(this.transform.position, player.transform.position);

            if (player.gameObject.GetComponent<Player>().SafeDistance >= distanceToPlayer) {
                tag = "DangerEnemy";
            } else
            {
                tag = "Enemy";
            }

            if (distanceToPlayer <= attackRange)
            {
                MoveUnitsPerSecond = 0f;
                if(CoolDownAttack(Time.deltaTime))
                {
                    Debug.Log("Attack");
                    Attack(atk);
                }
            } else
            {
                MoveUnitsPerSecond = 1f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Collision exit");
        if(collision.gameObject.tag == "Player")
        {
            MoveUnitsPerSecond = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Contains("Weapon"))
        {
            gameObject.SetActive(false);
        }
        
    }

    void Attack(float damage)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<HealthSystem>().GotHitFor(damage);
    }

    bool CoolDownAttack(float deltaTime)
    {
        if(waitTime >= cdTime)
        {
            //Debug.Log("True");
            waitTime = 0f;
            return true;
        }
        waitTime += deltaTime;
        return false;
    }


}
