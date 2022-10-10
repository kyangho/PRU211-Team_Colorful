using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    ObjectPooler objectPooler;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    void FixedUpdate()
    {
        objectPooler.SpawnFromPool("Enemy", new Vector3(Random.Range(-10, 10), 3, 0), Quaternion.identity);
    }
}
