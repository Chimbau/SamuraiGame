using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{

    public float rotateSpeed;
    private bool colectable;
    public float reboundSpeed;

    public float shurikenReturnTime;

    private Rigidbody2D rb;

    // Update is called once per frame
    private void Start() {
        colectable = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(!colectable){
            transform.Rotate(Vector3.forward * -rotateSpeed * Time.deltaTime);
        }    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy" && !colectable){
            other.gameObject.GetComponent<EnemyDeath>().Death();   
            rb.gravityScale = 1;
            rb.velocity = Vector2.up * reboundSpeed;
            colectable = true; 
        }
        else if (other.gameObject.tag == "Floor"){
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            colectable = true;
        }
        else if (other.gameObject.tag == "Player" && colectable){
            other.gameObject.GetComponent<ShurikenThrow>().CollectShuriken();
            Destroy(gameObject);
        }


    }
}
