using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    GameObject rangeWeapon;
    [SerializeField]
    GameObject meleeWeapon;
    [SerializeField]
    GameObject mainBullet;

    public int countMelee = 1;
    public int maxCountMelee = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //mainBullet.transform.Rotate(0, 0, 0);
        GameObject target;
        target = getTarget("DangerEnemy");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (target == null)
                rotate(getTarget("Enemy"));
            else
                rotate(target);
            shoot(rangeWeapon);
        }
        Debug.Log("Count melee: " + countMelee);
        if (target != null && countMelee > 0)
        {
            rotate(target);
            shoot(meleeWeapon);
            //Debug.Log("Count melee: " + countMelee);
            countMelee--;
        }

    }

    /// <summary>
    /// Rotate player to the target direction
    /// </summary>
    /// <param name="target"></param>
    /// <param name="weapon"></param>
    void rotate(GameObject target)
    {
        if (target != null)
        {
            float angle = Vector3.Angle(target.transform.position - mainBullet.transform.position, Vector3.up);
            if (target.transform.position.x > mainBullet.transform.position.x)
            {
                angle = -angle;
            }
            //Debug.Log("Angle: " + angle);
            mainBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            //Vector3 direction = target.transform.position - mainBullet.transform.position;
            //mainBullet.transform.rotation = Quaternion.LookRotation(target.transform.position);

        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="weapon"></param>
    void shoot(GameObject weapon)
    {
        GameObject Bullet = Instantiate(weapon, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * 20f, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Find nearest enemy to shoot
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    GameObject getTarget(string tag)
    {

        GameObject[] enemyList = GameObject.FindGameObjectsWithTag(tag);
        //Debug.Log(tag + "list: " + enemyList.Length);
        GameObject target = null;
        if (enemyList.Length > 0)
        {
            float minDistance = Vector3.Distance(mainBullet.transform.position, enemyList[0].transform.position);
            target = enemyList[0];
            foreach (GameObject enemy in enemyList)
            {
                if (enemy.activeSelf)
                    if (Vector3.Distance(mainBullet.transform.position, enemy.transform.position) < minDistance)
                    {
                        minDistance = Vector3.Distance(mainBullet.transform.position, enemy.transform.position);
                        target = enemy;
                    }
            }

        }
        return target;
        //Debug.Log("position target: " + target.transform.position);
    }

}
