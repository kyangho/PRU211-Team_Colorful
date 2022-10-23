using Assets.Scripts.Entity.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeShooting : Shooting
{

    [SerializeField]
    GameObject rangeWeapon;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = cooldownTime;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target;
        target = getTarget("DangerEnemy");
        bool cdFin = CoolDownAttack(Time.deltaTime);
        if (target == null)
            target = getTarget("Enemy");
        //Debug.Log(target.name);
        if (target != null && cdFin)
        {

            rotate(target);
            shoot(rangeWeapon, gameObject);
            waitTime = 0;
        }

    }

    bool CoolDownAttack(float deltaTime)
    {
        if (waitTime >= cooldownTime)
        {
            //waitTime = 0f;
            //Debug.Log("true");
            return true;
        }
        waitTime += deltaTime;
        //Debug.Log("wait time: " + waitTime + "\tcd time: " + cooldownTime);
        return false;
    }
}
