using Assets.Scripts.Entity.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(Vector3.Distance(player.transform.position, transform.position) > range)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Enemy"))
        {
            AudioManager.Instance.PlayAudioOneShot((AudioClip)Resources.Load("Audios/KillSound"), 0.1f);
            //collision.gameObject.tag = "Enemy";
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            return;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Map Boundary")
        {
            Destroy(gameObject);
        }
    }
}
