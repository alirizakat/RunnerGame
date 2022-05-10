using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemyMove : MonoBehaviour
{
    private Rigidbody rb;
    public float walkSpeed;
    public bool colorChange;
    public Material newMaterial;
    public GameObject mesh;
    private GameObject localPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        localPlayer = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.TransformDirection(Vector3.back * walkSpeed);
        //transform.rotation = Quaternion.Slerp(transform.rotation, localPlayer.transform.rotation, Time.deltaTime * walkSpeed);
        if(colorChange == true) 
        {
            mesh.GetComponent<SkinnedMeshRenderer>().material = newMaterial;
        }
    }
}
