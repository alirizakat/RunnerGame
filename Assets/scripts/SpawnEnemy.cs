using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject moneyPrefab;
    private Vector3 spawnPoint;
    private float zVal, finalXVal;
    private float xVal = 4;
    private GameObject localPlayer;

    // Start is called before the first frame update
    void Start()
    {
        localPlayer = GameObject.Find("Player");
        InvokeRepeating("SpawnMoney", 1f, 1f);
        InvokeRepeating("SpawnOpp", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnOpp()
    {
        zVal = Random.Range(gameObject.transform.position.z, localPlayer.transform.position.z + 15);
        finalXVal = Random.Range(-xVal, xVal);
        spawnPoint = new Vector3(finalXVal, 0.2f, zVal);
        GameObject enemy;
        enemy = Instantiate(enemyPrefab, spawnPoint, transform.rotation);
    }
    public void SpawnMoney()
    {
        zVal = Random.Range(gameObject.transform.position.z, localPlayer.transform.position.z + 15);
        finalXVal = Random.Range(-xVal, xVal);
        spawnPoint = new Vector3(finalXVal, localPlayer.transform.position.y - 0.75f, zVal);
        GameObject money;
        money = Instantiate(moneyPrefab, spawnPoint, transform.rotation);
    }
}
