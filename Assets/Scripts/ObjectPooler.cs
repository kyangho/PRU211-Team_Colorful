using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : Singleton<ObjectPooler>
{

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
        public int maxSize;
        public int RemainDeactive { get; set; }

        public void SetSize(int size)
        {
            this.size = size;
        }
    }
    public List<Pool> pools;

    private Dictionary<string, Queue<GameObject>> poolDictionary;
    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
                pool.RemainDeactive++;
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("Pool with tag: " + tag + " is not exist.");
            return null;
        }
        bool isRemaining = false;

        foreach (var p in pools)
        {
            if (p.tag.Equals(tag))
            {
                if (p.size == p.maxSize)
                {
                    return null;
                }
                isRemaining = p.RemainDeactive == 0 ? false : true;

                if (!isRemaining)
                {
                    GameObject objectToSpawn = poolDictionary[tag].Peek();

                    objectToSpawn.SetActive(true);
                    objectToSpawn.transform.position = position;
                    objectToSpawn.transform.rotation = rotation;

                    poolDictionary[tag].Enqueue(objectToSpawn);
                    p.SetSize(p.size + 1);
                    Debug.Log(pools[0].size);
                        return objectToSpawn;
                }
                else
                {
                    GameObject objectToSpawn = poolDictionary[tag].Dequeue();

                    objectToSpawn.SetActive(true);
                    objectToSpawn.transform.position = position;
                    objectToSpawn.transform.rotation = rotation;

                    poolDictionary[tag].Enqueue(objectToSpawn);
                    p.RemainDeactive--;
                    return objectToSpawn;
                }
            }
        }

        return null;
    }
}
