using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemyManager : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITTING, COUNTING }

    public Text waveCounter;
    private int nextWave = 0;

    public float timeBetweenWaves;
    private float waveCountDown;

    private float searchCountDown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    ObjectPooler objectPooler;

    void Start()
    {
        waveCountDown = timeBetweenWaves;
        objectPooler = ObjectPooler.Instance;
    }

    void FixedUpdate()
    {
        if (state == SpawnState.WAITTING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountDown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave());
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }

        Vector3 position;
        GameObject player = GameObject.FindWithTag("Player");
        do
        {
            position = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), 0);
        } while (Vector3.Distance(position, player.transform.position) < player.gameObject.GetComponent<Player>().SafeDistance);
    }

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;
        nextWave++;
    }

    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;

        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave()
    {

        waveCounter.text = (nextWave + 1).ToString();
        state = SpawnState.SPAWNING;
        int numberOfEnemy = Random.Range(10, 30);
        for (int i = 0; i < numberOfEnemy; i++)
        {
            SpawnEnemy();
        }

        state = SpawnState.WAITTING;

        yield break;
    }

    void SpawnEnemy()
    {
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
