using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    int numberOfEnermy = 0;

    [SerializeField]
    GameObject enermyPrefab;

    Timer spawnTimer;

    // Spawn location support
    const int SpawnBorderSize = 10;
    int minSpawnX;
    int maxSpawnX;
    int minSpawnY;
    int maxSpawnY;

    GameObject enermy;

    void Start()
    {
        //objectPooler = ObjectPooler.Instance;
        minSpawnX = SpawnBorderSize;
        maxSpawnX = Screen.width - SpawnBorderSize;
        minSpawnY = SpawnBorderSize;
        maxSpawnY = Screen.height - SpawnBorderSize;

        // Create and start timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = 2;
        spawnTimer.Run();
    }

    void FixedUpdate()
    {
        //objectPooler.SpawnFromPool("Enemy", new Vector3(Random.Range(-10, 10), 3, 0), Quaternion.identity);
        if (spawnTimer.Finished)
        {
            Spawner();
            numberOfEnermy++;

            // change spawn timer duration and restart
            spawnTimer.Duration = 2;
            spawnTimer.Run();
        }
    }

    void Spawner()
    {
        Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX),
            Random.Range(minSpawnY, maxSpawnY),
            0);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        worldLocation.Set(worldLocation.x, worldLocation.y, -5);
        ObjectPooler.Instance.SpawnFromPool("Enemy", worldLocation, Quaternion.identity);
    }
}
