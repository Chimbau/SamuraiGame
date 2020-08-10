using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour{
    private float waitTime;
    private Vector2 currentPatrolSpot;
    public float startWaitTime;
    public float speed;
    public Transform patrolSpot1;
    private Vector2 patrolSpotSave1;
    public Transform patrolSpot2;
    private Vector2 patrolSpotSave2;
    private Rigidbody2D rb;

    private EnemyAttack enemyAttack; 

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        enemyAttack = GetComponent<EnemyAttack>();

        waitTime = startWaitTime;
        patrolSpotSave1 = patrolSpot1.position;

        patrolSpotSave2 = patrolSpot2.position;
        currentPatrolSpot = patrolSpotSave2;
    }

    // Update is called once per frame
    void Update(){
        if(!enemyAttack.isAgroed()){
            if (Vector2.Distance(transform.position, currentPatrolSpot) < 0.2f){
                if (waitTime <= 0){
                    waitTime = startWaitTime;
                    transform.Rotate(0, 180, 0);
                    changeSpot();
                    rb.velocity = transform.right * speed;       
                }
                else{
                    waitTime -= Time.deltaTime;
                    rb.velocity = Vector2.zero;
                }
            }
            else{
                rb.velocity = transform.right * speed;
            }
        }
        else{
            rb.velocity = Vector2.zero;
        }
    }

    void changeSpot(){
        if(currentPatrolSpot == patrolSpotSave1){
            currentPatrolSpot = patrolSpotSave2;
        }
        else{
            currentPatrolSpot = patrolSpotSave1;
        }
    }

    void stopPatrol(){
        
    }


}
