using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public Animator shakeAnimation;

    public void Shake(){

        int shakeTrigger = Random.Range(0,2);
        

        switch(shakeTrigger){ 
            case 0 :
                shakeAnimation.SetTrigger("shakeTrigger");
                break;
            case 1:
                shakeAnimation.SetTrigger("shakeTrigger1");
                break;
        }      
    }
}
