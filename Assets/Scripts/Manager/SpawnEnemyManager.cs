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
        Vector3 position;
        GameObject player = GameObject.FindWithTag("Player");
        do
        {
            position = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), 0);
            //Debug.Log("Distance: " + Vector3.Distance(position, player.transform.position));
        } while (Vector3.Distance(position, player.transform.position) < player.gameObject.GetComponent<Player>().safeDistance);
        //if (Vector3.Distance(position, player.transform.position) < player.gameObject.GetComponent<Player>().safeDistance)
        objectPooler.SpawnFromPool("Enemy", new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0), Quaternion.identity);
    }
}
