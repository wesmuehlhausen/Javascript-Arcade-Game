using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownMine : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootTimer = 1f;
    public float initSpeed = -100f;
    public float curSpeed;
    //public float explodeTimer = 3;

    Quaternion rot;
    public Quaternion[] rot1;
    float z;
    float ang = 0;
    bool haveExp = false;

    //ParticleSystem exp = GetComponent<ParticleSystem>();


    void Start()
    {
        for (int i = 0; i < 8; ++i)
        {
            rot1[i] = transform.rotation;
            z = rot1[i].eulerAngles.z;
            z += ang;
            ang += 45;
            rot1[i] = Quaternion.Euler(0, 0, z);
        }
    }

    void Update()
    {
        Vector3 bulletPos = transform.position;
        curSpeed = Time.deltaTime;
        Vector3 bulletVelocity = new Vector3(0, curSpeed, 0);
        bulletPos -= transform.rotation * bulletVelocity;
        transform.position = bulletPos;

        //Burst explosion
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && haveExp == false)
        {
            haveExp = true;
            for (int i = 0; i < 8; ++i)
            { 
                Instantiate(bulletPrefab, transform.position, rot1[i]);
            }
            

        }
    }


}
   