using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bulletSpeed = 10f;
    private bool wasDeflected;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "Floor"){
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "PlayerBody"){
            if(other.gameObject.GetComponent<Deflect>().isDeflecting()){
                wasDeflected = true;
                Vector2 resultVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - other.gameObject.transform.position;
                transform.right = resultVector;
                rb.velocity = transform.right * bulletSpeed;
            }
            else{
                other.gameObject.GetComponentInParent<PlayerDeath>().Death();
                Destroy(gameObject);
            }  
        }

        if(other.gameObject.tag == "Enemy" && wasDeflected){
            other.gameObject.GetComponent<EnemyDeath>().Death();
            Destroy(gameObject);
        }  
    }

}
