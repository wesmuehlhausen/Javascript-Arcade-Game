using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashIntoPlayer : MonoBehaviour
{
    public float movementSpeed = 4;
    public GameObject gameObj;

    void Update()
    {

        Vector3 shipPos = transform.position;
        Vector3 shipVelocity = new Vector3(0, movementSpeed * Time.deltaTime, 0);
        shipPos += transform.rotation * shipVelocity;
        transform.position = shipPos;
    }
}
