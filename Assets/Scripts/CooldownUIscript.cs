using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownUIscript : MonoBehaviour
{
    public Slider cutAttackSlider;
    public Slider deflectSlider;

    private CutAttack cutAttack;
    private Deflect deflect;

    void Start() {
        cutAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<CutAttack>();
        deflect = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Deflect>();
    }

    // Update is called once per frame
    void Update()
    {     
        cutAttackSlider.value = cutAttack.getCutAttackCooldownTime() / cutAttack.cutAttackCooldown; 
        deflectSlider.value = deflect.getDeflectCooldownTime() / deflect.deflectCooldown; 
    }
}
