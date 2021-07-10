using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenThrow : MonoBehaviour
{
   public float shurikenSpeed;
   public GameObject shurikenPrefab;

   public float shurikenReturn;
   public float shurikenReturnTime;
   public int shurikenAmo;

    // Update is called once per frame

    private void Start() {
    }

    void Update()
    {
        Vector2 mousePositon = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseVector = (mousePositon - (Vector2) transform.position).normalized;

        if(Input.GetMouseButtonDown(1) && shurikenAmo >= 1){
            shurikenAmo--;
            GameObject shuriken = Instantiate(shurikenPrefab, transform.position, transform.rotation);
            Rigidbody2D shurikenRB = shuriken.GetComponent<Rigidbody2D>();
            shurikenRB.velocity = mouseVector * shurikenSpeed;
        }
    } 

    public void CollectShuriken(){
        shurikenAmo++;
    }
}
