using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour{

    public CutAttack cutAttack;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy" && cutAttack.isAttackin()){
            cutAttack.resetAtatckCooldown();
            other.gameObject.GetComponent<EnemyDeath>().Death();
        }
    }
}
