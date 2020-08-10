using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewind : MonoBehaviour
{

    public GameObject rewindClonePrefab;
    private GameObject rewindClone;
    private bool cloneActive = false;

    private float cloneTime;
    public float cloneStartTime;

    private ParticleSystem trailParticles;

    private void Start()
    {
        trailParticles = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            if (cloneActive)
            {
                rewindEnd();
            }
            else
            {
                rewindStart();
            }
        }

        if (cloneTime <= 0 && cloneActive)
        {
            rewindEnd();
        }
        else if (cloneTime > 0){
            cloneTime -= Time.deltaTime;
        }

    }


    private void rewindEnd()
    {
        transform.position = rewindClone.transform.position;
        cloneActive = false;
        cloneTime = 0f;
        Destroy(rewindClone);
        trailParticles.Stop();
        trailParticles.Clear();
    }


    private void rewindStart()
    {
        rewindClone = Instantiate(rewindClonePrefab, transform.position, transform.rotation);
        cloneTime = cloneStartTime;
        cloneActive = true;
        trailParticles.Play();
    }

}
