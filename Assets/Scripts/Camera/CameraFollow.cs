using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform playerPosition;
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.2f;

    void FixedUpdate() {
        //transform.position = playerPosition.position;
        if(playerPosition != null){
            Vector3 endPosition = new Vector3(playerPosition.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, endPosition, ref velocity, smoothTime);
        }
       
    }
}
