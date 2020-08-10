using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour
{

    private Rigidbody2D rb;

    private void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if(rb.velocity != Vector2.zero){
            transform.right = rb.velocity;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Floor"){
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
