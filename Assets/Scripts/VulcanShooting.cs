using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VulcanShooting : MonoBehaviour
{
    public GameObject gameObj;
    public GameObject bulletPrefab;
    float distance = 0;
    public float maxGunRange = 10;
    public float coolDown = 250;
    float shotTimer = 0;
    //float lockTimer = 0;

    void Start()
    {
        gameObj = GameObject.Find("ship_normal");
    }

    void Update()
    {
        //Find ship
        if (gameObj == null)
            gameObj = GameObject.Find("ship_normal");

        distance = Vector3.Distance(gameObj.transform.position, transform.position);

        //If ship is in distance and can shoot
        if (distance < maxGunRange && shotTimer <= 0)
        {

            //gameObject.GetComponent<VulcanMovement>().locked = true;//lock the ship
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            shotTimer = coolDown;
            // gameObject.GetComponent<VulcanMovement>().locked = false;//unlock the ship 
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
