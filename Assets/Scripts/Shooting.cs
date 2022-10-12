using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject mainBullet;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject Bullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * 20f, ForceMode2D.Impulse);
        }
    }
}
