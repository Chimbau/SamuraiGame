using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject deathParticles;

    private CameraShake shake;

    // Start is called before the first frame update
    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death(){
        shake.Shake();
        Instantiate(deathParticles, transform.position, transform.rotation);
        Destroy(gameObject);    
    }
}
