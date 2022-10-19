using Assets.Scripts.Entity.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //private Transform[] firePoints = new Transform[6];

    //private GameObject mainBullet;

    // Start is called before the first frame update
    void Start()
    {
        //firePoints[0] = this.transform.Find("firePointOne");
        //firePoints[1] = this.transform.Find("firePointTwo");
        //firePoints[2] = this.transform.Find("firePointThree");
        //firePoints[3] = this.transform.Find("firePointFour");
        //firePoints[4] = this.transform.Find("firePointFive");
        //firePoints[5] = this.transform.Find("firePointSix");

        //mainBullet = gameObject;
    }

    // Update is called once per frame
    protected void Update()
    {
        //Debug.Log(firePoints[5].transform.position);
        //mainBullet.transform.Rotate(0, 0, 0);
        //GameObject target;
        //target = getTarget("DangerEnemy");
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (target == null)
        //        rotate(getTarget("Enemy"));
        //    else
        //        rotate(target);
        //    //shoot(rangeWeapon);
        //}
        //Debug.Log("Count melee: " + countMelee);
        //if (target != null && countMelee > 0)
        //{
        //    rotate(target);
        //    //shoot(meleeWeapon);
        //    //Debug.Log("Count melee: " + countMelee);
        //    countMelee--;
        //}

    }

    /// <summary>
    /// Rotate player to the target direction
    /// </summary>
    /// <param name="target"></param>
    /// <param name="weapon"></param>
    protected void rotate(GameObject target)
    {
        if (target != null)
        {
            float angle = Vector3.Angle(target.transform.position - gameObject.transform.position, Vector3.up);
            if (target.transform.position.x > gameObject.transform.position.x)
            {
                angle = -angle;
            }
            //Debug.Log("Angle: " + angle);
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


            //Vector3 direction = target.transform.position - gameObject.transform.position;
            //gameObject.transform.rotation = Quaternion.LookRotation(target.transform.position);

        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="weapon"></param>
    protected GameObject shoot(GameObject weapon, GameObject firePoint)
    {
        GameObject Bullet = Instantiate<GameObject>(weapon, firePoint.transform.position, firePoint.transform.rotation);
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        //Debug.Log("Weapon: " + weapon.name +"\tFirepoint: "+firePoint.name);
        weapon.GetComponent<Weapon>().FirePoint = firePoint;
        if (firePoint.name == "firePointSix" || firePoint.name == "firePointFive")
        {
            Debug.Log("weapoint firepoint: " + weapon.GetComponent<Weapon>().FirePoint.GetComponent<MeleeShooting>().countMelee);
        }
        rb.AddForce(firePoint.transform.up * 20f, ForceMode2D.Impulse);
        return Bullet;
    }

    /// <summary>
    /// Find nearest enemy to shoot
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    protected GameObject getTarget(string tag)
    {

        GameObject[] enemyList = GameObject.FindGameObjectsWithTag(tag);
        //Debug.Log(tag + "list: " + enemyList.Length);
        GameObject target = null;
        if (enemyList.Length > 0)
        {
            float minDistance = Vector3.Distance(gameObject.transform.position, enemyList[0].transform.position);
            target = enemyList[0];
            foreach (GameObject enemy in enemyList)
            {
                if (enemy.activeSelf)
                    if (Vector3.Distance(gameObject.transform.position, enemy.transform.position) < minDistance)
                    {
                        minDistance = Vector3.Distance(gameObject.transform.position, enemy.transform.position);
                        target = enemy;
                    }
            }

        }
        return target;
        //Debug.Log("position target: " + target.transform.position);
    }

}
