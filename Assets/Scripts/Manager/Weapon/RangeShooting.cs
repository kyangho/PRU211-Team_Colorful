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

    }

    // Update is called once per frame
    void Update()
    {
        GameObject target;
        target = getTarget("DangerEnemy");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (target == null)
                rotate(getTarget("Enemy"));
            else
                rotate(target);
            shoot(rangeWeapon, gameObject);
        }

    }
}
