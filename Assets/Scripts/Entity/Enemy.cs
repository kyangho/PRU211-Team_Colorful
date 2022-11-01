using Assets.Scripts.Entity.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    GameObject player;
    [SerializeField]
    float MoveUnitsPerSecond;
    [SerializeField]
    float atk;
    [SerializeField]
    float hp;
    [SerializeField]
    float attackRange;
    [SerializeField]
    private float cdTime;
    private float waitTime;

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

    void Attack(float damage)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<HealthSystem>().GotHitFor(damage);
        player.GetComponent<Player>().canRegen = false;
        player.GetComponent<Player>().timeToHealth = 5f;
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
        int wave = Convert.ToInt32(GameObject.Find("WaveCounter").GetComponent<Text>().text);
        int countIncreasing = wave / 5;
        atk = atk * (100 + 10 * countIncreasing) / 100;
        hp = hp * (100 + 10 * countIncreasing) / 100;
        gameObject.GetComponent<HealthSystem>().CurrentHealth = hp;
        gameObject.GetComponent<HealthSystem>().MaximumHealth = hp;
        gameObject.GetComponent<HealthSystem>().IsAlive = true;
        waitTime = cdTime;
    }

    public void IsAlive(bool isAlive)
    {
        if (!isAlive)
        {
            AudioManager.Instance.PlayAudioOneShot((AudioClip)Resources.Load("Audios/Bonus"), 0.5f);
            GameObject.Find("CoinCounter").GetComponent<Text>().text = (Convert.ToInt32(GameObject.Find("CoinCounter").GetComponent<Text>().text) + UnityEngine.Random.Range(1, 4)).ToString();
        }
    }
}
