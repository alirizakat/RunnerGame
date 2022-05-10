using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySpot : MonoBehaviour
{
    private bool doOnce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Collected"))
        {
            Destroy(collider.gameObject);
            GameObject local;
            local = GameObject.Find("Player");
            if(!doOnce)
            {
                local.AddComponent<CollectManager>();
                doOnce = true;
            }
        }
    }
}
