using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{

    public float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * -rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<EnemyDeath>().Death();   
            Destroy(gameObject);      
        }
        else if (other.gameObject.tag == "Floor"){
            Destroy(gameObject);
        }


    }
}
