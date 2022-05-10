using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMovement : MonoBehaviour
{
    public Transform connectedNode;
    void LateUpdate()
    {
        transform.position = 
        new Vector3(Mathf.Lerp
        (transform.position.x, connectedNode.position.x, Time.deltaTime * 25)
        , connectedNode.position.y + 0.45f
        , connectedNode.position.z);
    }
}
