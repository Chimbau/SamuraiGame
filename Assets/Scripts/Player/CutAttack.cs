using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutAttack : MonoBehaviour
{

    Rigidbody2D rb;
    private float cutTime;
    public float startCutTime;
    private Vector2 mouseVector;
    private bool Attackin;

    public float cutAttackForce;
    public Transform katanaPosition;
    public TrailRenderer cutAttackTrail;

    public float cutAttackCooldownTime;
    public float cutAttackCooldown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cutTime = startCutTime;
    }

    // Update is called once per frame
    void Update()
    {

        if(!Attackin){

            if (Input.GetMouseButtonDown(0) && cutAttackCooldownTime <= 0){  
                Attackin = true;
                cutAttackCooldownTime = cutAttackCooldown;

                //Cut direction calculation
                Vector2 mousePosition = Input.mousePosition;
                Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);  
                Vector2 playerPosition = transform.position;
                mouseVector = (mouseWorldPosition - playerPosition).normalized;   
            }
        }
        else{
            cutAttackTrail.emitting = true;
             if (cutTime <= 0){
                Attackin = false;
                cutTime = startCutTime;
                rb.velocity = Vector2.zero;
                cutAttackTrail.emitting = false;
            }
            else{
                cutTime -= Time.deltaTime;
                rb.velocity = mouseVector * cutAttackForce;
            }        
        }

        if (cutAttackCooldownTime > 0){
                cutAttackCooldownTime -= Time.deltaTime;
        }   
    }

    public bool isAttackin(){
        return Attackin;
    }

    public void resetAtatckCooldown(){
        cutAttackCooldownTime = 0;
    }

    public float getCutAttackCooldownTime(){
        return cutAttackCooldownTime;
    }


}
