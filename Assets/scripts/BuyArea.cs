using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class BuyArea : MonoBehaviour
{
    public MoneyMovement money;
    public GameObject[] collected;
    private GameObject localPlayer;
    public int areaCost;
    public GameObject walking, bike;
    public Image fillImage;
    int i = 0;
    int result;
    float amountToAdd;

    void Update()
    {
        collected = GameObject.FindGameObjectsWithTag("Collected");
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            localPlayer = col.gameObject;
            money.movementSpeed = 0;
            money.horizontalSpeed = 0;
            localPlayer.GetComponentInChildren<Animator>().speed = 0;
            if(collected.Length >= areaCost)
            {
                result = collected.Length - areaCost;
                amountToAdd = 1 / (float)areaCost;
                Debug.Log("You can buy this!");
                StartCoroutine("PayMoney");
            }
            else if(collected.Length < areaCost)
            {
                Debug.Log("You can't buy this");
                StartCoroutine("NoPayRoutine");
            }
        }
    }
    
    IEnumerator PayMoney()
    {
        Destroy(collected[collected.Length - 1].GetComponent<NodeMovement>());
        GameObject local;
        local = GameObject.Find("BuySpot");
        yield return new WaitForSeconds(0.1f);
        collected[collected.Length - 1].transform.DOMove(local.transform.position, 0.1f);
        if(collected.Length == result)
        {
            localPlayer.GetComponent<MoneyMovement>().LoseMoney();
            BikeContinue();
        }
        else
        {
            fillImage.fillAmount += amountToAdd;
            localPlayer.GetComponent<MoneyMovement>().LoseMoney();
            StartCoroutine("PayMoney");   
        }
    }
    void BikeContinue()
    {
        GameObject local;
        local = GameObject.Find("Player");
        Vector3 newPos = new Vector3(0f, local.transform.position.y, local.transform.position.z);
        local.transform.position = Vector3.MoveTowards(local.transform.position, newPos, 0.5f * Time.deltaTime);
        walking.SetActive(false);
        bike.SetActive(true);
        money.movementSpeed = 6;
        money.horizontalSpeed = 10;
        local.GetComponentInChildren<Animator>().speed = 1;
    }
    IEnumerator NoPayRoutine()
    {
        yield return new WaitForSeconds(1.0f);
        MoveOn();
    }
    void MoveOn()
    {
        GameObject local;
        local = GameObject.Find("Player");
        Vector3 newPos = new Vector3(0f, local.transform.position.y, local.transform.position.z);
        local.transform.position = Vector3.MoveTowards(local.transform.position, newPos, 0.5f * Time.deltaTime);
        money.movementSpeed = 3;
        money.horizontalSpeed = 5;
        local.GetComponentInChildren<Animator>().speed = 1;
    }
}
