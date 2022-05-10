using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    //public GameObject moneyPrefab;
    private Vector3 spawnPoint;
    private float zVal, finalXVal;
    private float xVal = 3;
    private GameObject localPlayer;

    // Start is called before the first frame update
    void Start()
    {
        localPlayer = GameObject.Find("Player");
        //InvokeRepeating("SpawnMoney", 6.0f, 2.0f);
        InvokeRepeating("SpawnOpp", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnOpp()
    {
        zVal = Random.Range(localPlayer.transform.position.z -45, localPlayer.transform.position.z -15);
        finalXVal = Random.Range(-xVal, xVal);
        spawnPoint = new Vector3(finalXVal, 2.1f, zVal);
        GameObject enemy;
        enemy = Instantiate(enemyPrefab, spawnPoint, transform.rotation);
    }
    /*
    public void SpawnMoney()
    {
        zVal = Random.Range(localPlayer.transform.position.z -25, localPlayer.transform.position.z -15);
        finalXVal = Random.Range(-xVal, xVal);
        spawnPoint = new Vector3(finalXVal, 2.25f, zVal);
        GameObject money;
        money = Instantiate(moneyPrefab, spawnPoint, transform.rotation);
    }
    */
}
