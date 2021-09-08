using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform myTarget;
    public GameObject ship;

    void Start()
    {
        ship = GameObject.Find("ship_normal");
        myTarget = ship.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (ship == null)
        {
            ship = GameObject.Find("ship_normal");
            myTarget = ship.transform;
        }
        if (myTarget != null)
        {
            Vector3 targPos = myTarget.position;
            targPos.z = transform.position.z;
            transform.position = targPos;
        }
    }
}



/*
 public class CameraFollow : MonoBehaviour
{
    public Transform myTarget;

    // Update is called once per frame
    void Update()
    {
        if (myTarget != null)
        {
            Vector3 targPos = myTarget.position;
            targPos.z = transform.position.z;
            transform.position = targPos;
        }
    }
}
 */