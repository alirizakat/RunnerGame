using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CollectManager : MonoBehaviour
{
    private float moveSpeed = 3.6f;
    private GameObject local;
    private void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.CompareTag("Collect"))
        {
            local = col.gameObject;
            StartCoroutine("Collect");   
        }
    }
    IEnumerator Collect()
    {
        local.gameObject.AddComponent<CollectManager>();
        local.gameObject.transform.DOMove(transform.position + Vector3.up * 1.22f, moveSpeed * Time.deltaTime);
        local.gameObject.transform.localScale = new Vector3(0.35f,0.35f,0.35f);
        yield return new WaitForSeconds(0.1f);
        local.gameObject.transform.DOMove(transform.position + Vector3.up, moveSpeed * Time.deltaTime);
        local.gameObject.AddComponent<NodeMovement>();
        local.gameObject.GetComponent<NodeMovement>().connectedNode = transform;
        local.gameObject.tag = "Collected";
        GameObject.Find("Player").GetComponent<MoneyMovement>().MoneyFixer();
        Destroy(gameObject.GetComponent<CollectManager>());
        
        
    }
}