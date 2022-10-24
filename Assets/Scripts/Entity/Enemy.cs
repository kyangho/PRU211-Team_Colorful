using Assets.Scripts.Entity.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    GameObject player;
    float MoveUnitsPerSecond = 1f;
    [SerializeField]
    float atk;
    [SerializeField]
    float hp;
    [SerializeField]
    float attackRange;
    [SerializeField]
    private float cdTime;
    private float waitTime;
    private int percent = 100;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = cdTime;

        //Set max hp for enemy
        gameObject.GetComponent<HealthSystem>().CurrentHealth = hp;
        gameObject.GetComponent<HealthSystem>().MaximumHealth = hp;
        gameObject.GetComponent<HealthSystem>().IsAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            float step = MoveUnitsPerSecond * Time.deltaTime;
            //Find position of player and approach him
            Vector3 point = new Vector3(player.transform.position.x, player.transform.position.y, -Camera.main.transform.position.z);
            transform.position = Vector2.MoveTowards(transform.position, point, step);
            float distanceToPlayer = Vector3.Distance(this.transform.position, player.transform.position);

            if (player.GetComponent<Player>().SafeDistance >= distanceToPlayer)
            {
                tag = "DangerEnemy";
            }
            else
            {
                tag = "Enemy";
            }

            if (distanceToPlayer <= attackRange)
            {
                MoveUnitsPerSecond = 0f;
                if (CoolDownAttack(Time.deltaTime))
                {
                    Attack(atk);
                }
            }
            else
            {
                MoveUnitsPerSecond = 1f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MoveUnitsPerSecond = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Weapon"))
        {
            //GetComponent<HealthSystem>().GotHitFor(collision.gameObject.GetComponent<Weapon>().ATK);
            //gameObject.SetActive(false);
        }

    }

    void Attack(float damage)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<HealthSystem>().GotHitFor(damage);
    }

    bool CoolDownAttack(float deltaTime)
    {
        if (waitTime >= cdTime)
        {
            waitTime = 0f;
            return true;
        }
        waitTime += deltaTime;
        return false;
    }

    /// <summary>
    /// Set max hp when enemy be active
    /// </summary>
    private void OnEnable()
    {
        int wave = Convert.ToInt32(GameObject.Find("WaveCounter").GetComponent<UnityEngine.UI.Text>().text);
        if (wave % 2 == 0 && wave > 0)
        {
            percent += 10;
            atk = atk * percent / 100;
            hp = hp * percent / 100;
        }
        gameObject.GetComponent<HealthSystem>().CurrentHealth = hp;
        gameObject.GetComponent<HealthSystem>().MaximumHealth = hp;
        gameObject.GetComponent<HealthSystem>().IsAlive = true;
        waitTime = cdTime;
    }
}
