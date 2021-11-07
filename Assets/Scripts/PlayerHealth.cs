using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static int player_health = 10;
    public GameObject explosionPrefab;

    //On ship collision/trigger
    void OnTriggerEnter2D()
    {
        Debug.Log("Trigger!");//log collision in command line
        //health--;//decrease health

    }

    void Update()
    {
        if (player_health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
        explode();
    }

    void explode()
    {
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }
    }
}
