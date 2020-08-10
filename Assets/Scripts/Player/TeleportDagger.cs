using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDagger : MonoBehaviour
{

    public float daggerSpeed;

    private bool activeDagger = false;

    public GameObject teleportDaggerPrefab;

    private GameObject teleportDagger;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 firePoint = (mousePosition - transform.position).normalized;

        if(Input.GetKeyDown("e")){
           if(!activeDagger){
                activeDagger = true;
                teleportDagger = Instantiate(teleportDaggerPrefab, transform.position, transform.rotation);
                Rigidbody2D daggerRb = teleportDagger.GetComponent<Rigidbody2D>();
                daggerRb.velocity = firePoint * daggerSpeed; 
            }
            else{
                activeDagger = false;
                transform.position = teleportDagger.transform.position;
                Destroy(teleportDagger);
            }    
        }
    }
}
