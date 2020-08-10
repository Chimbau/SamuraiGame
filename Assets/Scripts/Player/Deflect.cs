using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflect : MonoBehaviour
{

    public bool Deflecting;
    public float deflectTime;
    public float startDeflectTime;
    private float deflectCooldownTime;
    public float deflectCooldown;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q") && deflectCooldownTime <= 0){
            Deflecting = true;
            deflectCooldownTime = deflectCooldown;
            deflectTime = startDeflectTime;
        }

        if(Deflecting){
            if(deflectTime <= 0){
                Deflecting = false;
            }
            else{
                deflectTime -= Time.deltaTime;
            }
        }

        if(deflectCooldownTime > 0){
            deflectCooldownTime -= Time.deltaTime;
        }
    }

    public bool isDeflecting(){
        return Deflecting;
    }

    public float getDeflectCooldownTime(){
        return deflectCooldownTime;
    }
}
