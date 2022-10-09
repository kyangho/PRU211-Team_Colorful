using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
        Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    }
}
