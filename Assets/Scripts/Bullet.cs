using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    int check = 1;
    float MoveUnitsPerSecond = 20f;
    float colliderHalf;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        colliderHalf = collider.radius / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (check == 0)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.zero;

            target = GameObject.FindGameObjectWithTag("Player");

            float step = MoveUnitsPerSecond * Time.deltaTime;

            Vector3 point = new Vector3(target.transform.position.x, target.transform.position.y, -Camera.main.transform.position.z);

            transform.position = Vector2.MoveTowards(transform.position, point, step);
        }
        else
        {
            ClampInScreen();
        }
    }

    void ClampInScreen()
    {
        Vector3 position = transform.position;
        // clamp horizontally
        if (position.x - colliderHalf < ScreenUtils.ScreenLeft)
        {
            check = 0;
        }
        else if (position.x + colliderHalf > ScreenUtils.ScreenRight)
        {
            check = 0;
        }

        // clamp vertically
        if (position.y + colliderHalf > ScreenUtils.ScreenTop)
        {
            check = 0;
        }
        else if (position.y - colliderHalf < ScreenUtils.ScreenBottom)
        {
            check = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
