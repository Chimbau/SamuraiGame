using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{   
    public Transform firePoint;
    private Transform playerPosition;
    public Transform enemyGun;
    private bool Agroed;
    public GameObject bullet;

    public float startFireRate;
    private float fireRate;

    private void Start() {
        fireRate = startFireRate;
    }

    private void Update() {
        if (Agroed && playerPosition != null){
            RotateGun();

            if(fireRate <= 0){
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                fireRate = startFireRate;
            }
            else{
                fireRate -= Time.deltaTime;
            }

            if(playerPosition.position.x > transform.position.x){
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else{
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

        }   
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            Agroed = true;
            playerPosition = other.transform;       
        }
    }

    void RotateGun(){
        Vector2 resultVector = playerPosition.position - firePoint.position;      
        enemyGun.transform.right = resultVector;
    }

    public bool isAgroed(){
        return Agroed;
    }
}
