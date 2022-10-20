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
        } while (Vector3.Distance(position, player.transform.position) < player.gameObject.GetComponent<Player>().SafeDistance);
        //if (Vector3.Distance(position, player.transform.position) < player.gameObject.GetComponent<Player>().safeDistance)
        int number = Random.Range(1, 4);
        switch (number)
        {
            case 1:
                objectPooler.SpawnFromPool("Enemy 1", new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0), Quaternion.identity);
                break;
            case 2:
                objectPooler.SpawnFromPool("Enemy 2", new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0), Quaternion.identity);
                break;
            case 3:
                objectPooler.SpawnFromPool("Enemy 3", new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0), Quaternion.identity);
                break;
        }
    }
}
