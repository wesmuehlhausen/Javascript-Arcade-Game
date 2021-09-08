using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject gameObj;
    public GameObject bulletPrefab;
    float distance = 0;
    public float maxGunRange = 10;
    public float coolDown = 250;
    float shotTimer = 0;

    void Start()
    {
        gameObj = GameObject.Find("ship_normal");
    }

    void Update()
    {
        if (gameObj == null)
            gameObj = GameObject.Find("ship_normal");

        distance = Vector3.Distance(gameObj.transform.position, transform.position);
        if (distance < maxGunRange && shotTimer <= 0)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            shotTimer = coolDown;
        }
        else if (shotTimer < -2500)
        {
            shotTimer = 0; 
        }
        else
        {
            shotTimer -= 1;
        }

    }

}
