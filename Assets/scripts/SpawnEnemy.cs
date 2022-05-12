using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    private Vector3 spawnPoint;
    private float zVal, finalXVal;
    private float xVal = 3;
    private GameObject localPlayer;

    // Start is called before the first frame update
    void Start()
    {
        localPlayer = GameObject.Find("Player");
        InvokeRepeating("SpawnOpp", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnOpp()
    {
        zVal = Random.Range(localPlayer.transform.position.z -60, localPlayer.transform.position.z -50);
        finalXVal = Random.Range(-xVal, xVal);
        spawnPoint = new Vector3(finalXVal, 2.1f, zVal);
        GameObject enemy;
        enemy = Instantiate(enemyPrefab, spawnPoint, transform.rotation);
    }
}
