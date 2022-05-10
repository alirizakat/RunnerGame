using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject localEnemy;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ReloadFunction", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Enemy"))
        {
            localEnemy = col.gameObject;
            col.gameObject.GetComponent<EnemyMove>().colorChange = true;
            col.gameObject.tag = "EnemyHit";
            StartCoroutine("HitRoutine");
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    void ReloadFunction()
    {
        GameObject local;
        local = GameObject.Find("Player");
        local.GetComponent<MoneyMovement>().StartCoroutine("Reload");
    }
    IEnumerator HitRoutine()
    {
        localEnemy.GetComponent<Animator>().SetTrigger("death");
        yield return new WaitForSeconds(1.0f);
        Destroy(localEnemy.GetComponent<EnemyMove>());
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
