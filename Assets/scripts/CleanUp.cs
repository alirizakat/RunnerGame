using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    private GameObject player;
    private float zDiff;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        zDiff = Mathf.Abs(gameObject.transform.position.z - player.transform.position.z);
        if(zDiff > 65)
        {
            Destroy(gameObject);
        }
    }
}
