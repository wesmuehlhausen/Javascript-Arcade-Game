using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructCleaner : MonoBehaviour
{
    public float despawnTimer = 5;

    // Update is called once per frame
    void Update()
    {
        despawnTimer -= Time.deltaTime;
        if (despawnTimer <= 0)
            Destroy(gameObject);
    }
}
