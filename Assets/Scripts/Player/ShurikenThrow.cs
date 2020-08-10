using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenThrow : MonoBehaviour
{
   public float shurikenSpeed;
   public GameObject shurikenPrefab;

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePositon = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseVector = (mousePositon - (Vector2) transform.position).normalized;

        if(Input.GetMouseButtonDown(1)){
            GameObject shuriken = Instantiate(shurikenPrefab, transform.position, transform.rotation);
            Rigidbody2D shurikenRB = shuriken.GetComponent<Rigidbody2D>();
            shurikenRB.velocity = mouseVector * shurikenSpeed;
        }
    } 
}
