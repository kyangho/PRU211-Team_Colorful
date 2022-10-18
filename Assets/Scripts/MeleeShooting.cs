using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeShooting : Shooting
{



    public int countMelee = 1;
    public int maxCountMelee = 1;

    [SerializeField]
    GameObject meleeWeapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target;
        target = getTarget("DangerEnemy");
        if (target != null && countMelee > 0)
        {
            rotate(target);
            GameObject shooter = shoot(meleeWeapon, gameObject);
            shooter.gameObject.GetComponent<MeleeWeapon>().FirePoint = gameObject;
            //Debug.Log("Count melee: " + meleeWeapon.gameObject.GetComponent<MeleeWeapon>().FirePoint.GetComponent<MeleeShooting>().countMelee);
            countMelee--;
            //Debug.Log("Count melee 2: " + meleeWeapon.gameObject.GetComponent<MeleeWeapon>().FirePoint.GetComponent<MeleeShooting>().countMelee);
        }

    }
}
