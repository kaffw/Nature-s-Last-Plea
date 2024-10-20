using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerPos;

    void Update()
    {
        gameObject.transform.position = new Vector3(playerPos.position.x, playerPos.position.y, gameObject.transform.position.z);        
    }
}
