using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardBullet : MonoBehaviour
{

    public float bulletSpeed = 20f;

    void Update()
    {
        Vector3 bulletPos = transform.position;
        Vector3 bulletVelocity = new Vector3(0, bulletSpeed * Time.deltaTime, 0);
        bulletPos += transform.rotation * bulletVelocity;
        transform.position = bulletPos;
    }

}
