using Assets.Scripts.Entity.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{

    int check = 1;
    float MoveUnitsPerSecond = 20f;
    float colliderHalf;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        colliderHalf = collider.radius / 2;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Check: " + check);
        if (check == 0)
        {
            //Debug.Log("count melee: " + base.FirePoint.name);
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.zero;

            player = GameObject.FindGameObjectWithTag("Player");

            float step = MoveUnitsPerSecond * Time.deltaTime;
            //Vector3 direction = player.transform.position - transform.position;
            //transform.Translate(direction.x * step, direction.y * step, 0);

            Vector3 point = new Vector3(player.transform.position.x, player.transform.position.y, -Camera.main.transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, point, step);
        }
        else
        {
            ClampInRange();
        }
    }

    void ClampInRange()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        //Debug.Log("playerPosi:" + playerPosition);
        if (Vector3.Distance(playerPosition, gameObject.transform.position) >= player.gameObject.GetComponent<Player>().SafeDistance)
        {
            check = 0;
        }
        //Vector3 position = transform.position;
        //// clamp horizontally
        //if (position.x - colliderHalf < ScreenUtils.ScreenLeft)
        //{
        //    check = 0;
        //}
        //else if (position.x + colliderHalf > ScreenUtils.ScreenRight)
        //{
        //    check = 0;
        //}

        //// clamp vertically
        //if (position.y + colliderHalf > ScreenUtils.ScreenTop)
        //{
        //    check = 0;
        //}
        //else if (position.y - colliderHalf < ScreenUtils.ScreenBottom)
        //{
        //    check = 0;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Tag: " + collision.gameObject.tag + "    Check: " + check);
        if (collision.gameObject.tag == "Player" && check == 0)
        {
            if (FirePoint.gameObject.GetComponent<MeleeShooting>().countMelee < FirePoint.GetComponent<MeleeShooting>().maxCountMelee)
                FirePoint.gameObject.GetComponent<MeleeShooting>().countMelee++;
            //    //AudioManager.Instance.PlayAudioOneShot((AudioClip)Resources.Load("Audios/KillSound"), 0.1f);
            //    //gameObject.SetActive(false);
            //    //Instantiate(meleeWeapon, FirePoint.transform.position, FirePoint.transform.rotation);
            Destroy(gameObject);
        }

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player" && check == 0)
    //    {
    //        Destroy(gameObject);
    //    }

    //}


    //private void OnDestroy()
    //{
    //    if (FirePoint.GetComponent<MeleeShooting>().countMelee < FirePoint.GetComponent<MeleeShooting>().maxCountMelee)
    //        FirePoint.GetComponent<MeleeShooting>().countMelee++;
    //}
}
