using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedByShip : MonoBehaviour
{
    public int ship_health = 1;
    public int damagePlayerBy = 1;
    public int pointsOnDeath = 0;
    public GameObject explosionPrefab;
    public bool isShip = false;

    //On ship collision/trigger
    void OnTriggerEnter2D() 
    {
        Debug.Log("Trigger!");//log collision in command line
        Debug.Log("Collision: " + PlayerHealth.player_health);
        ship_health--;//decrease health
        Debug.Log("Collision: " + PlayerHealth.player_health);
        PlayerHealth.player_health -= damagePlayerBy;
        Debug.Log("Collision: " + PlayerHealth.player_health);

    }

    void Update() 
    {
        if (ship_health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        if (isShip == true) { 
            ScoreScript.scoreValue += pointsOnDeath;
            GAMEFLOW.enemiesAlive -= 1;        
        }
        Destroy(gameObject);
        explode();
    }

    void explode() {
        if (explosionPrefab != null) {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }
    }
}
