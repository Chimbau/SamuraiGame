using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflect : MonoBehaviour
{

    public bool Deflecting;
    public float deflectTime;
    public float startDeflectTime;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q")){
            Deflecting = true;
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
    }

    public bool isDeflecting(){
        return Deflecting;
    }
}
