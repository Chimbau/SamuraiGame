using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownUIscript : MonoBehaviour
{

    private Slider cutAttackSlider;

    private CutAttack cutAttack;

    private void Start() {
        //cutAttackSlider = GetComponentInChildren
        cutAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<CutAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        cutAttackSlider.value = 0.5f;
    }
}
