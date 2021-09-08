using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitParticles : MonoBehaviour
{

    public ParticleSystem particle;
    ParticleSystem particleAll;

    //On ship collision/trigger
    void OnTriggerEnter2D()
    {
     
        Debug.Log("Trigger!");//log collision in command line
        particleAll = Instantiate(particle);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}