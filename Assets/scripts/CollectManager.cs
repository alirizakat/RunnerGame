using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CollectManager : MonoBehaviour
{
    private float moveSpeed = 2.5f;
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
        local.gameObject.transform.DOMove(transform.position + Vector3.up * 1.1f, moveSpeed * Time.deltaTime);
        local.gameObject.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
        yield return new WaitForSeconds(0.2f);
        local.gameObject.transform.DOMove(transform.position + Vector3.up, moveSpeed * Time.deltaTime);
        Destroy(gameObject.GetComponent<CollectManager>());
        local.gameObject.AddComponent<CollectManager>();
        local.gameObject.AddComponent<NodeMovement>();
        local.gameObject.GetComponent<NodeMovement>().connectedNode = transform;
        local.gameObject.tag = "Collected";

    }
}
/*
        //col.gameObject.transform.Translate(transform.position + Vector3.up * Time.deltaTime * moveSpeed);
        //col.gameObject.transform.position = Vector3.MoveTowards(col.transform.position, transform.position + Vector3.up,moveSpeed);
        local.gameObject.transform.DOMove(transform.position + Vector3.up * 2, moveSpeed * Time.deltaTime);
        //col.gameObject.transform.DORotate(transform.localEulerAngles, moveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(0.2f);
        local.gameObject.transform.DOMove(transform.position + Vector3.up, moveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject.GetComponent<CollectManager>());
        local.gameObject.AddComponent<CollectManager>();
        //col.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        local.gameObject.AddComponent<NodeMovement>();
        local.gameObject.GetComponent<NodeMovement>().connectedNode = transform;
        local.gameObject.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
        local.gameObject.tag = "Collected";
*/