using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedByShip : MonoBehaviour
{
    public int health = 1;

    //On ship collision/trigger
    void OnTriggerEnter2D() 
    {
        Debug.Log("Trigger!");//log collision in command line
        health--;//decrease health

    }

    void Update() 
    {
        if (health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }
}
