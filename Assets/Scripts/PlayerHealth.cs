using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static int player_health = 25;
    public GameObject explosionPrefab;

    //On ship collision/trigger
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger!");//log collision in command line
        //health--;//decrease health
        // Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);

        if(col.gameObject.name == "enemy_bullet" || col.gameObject.name == "enemy_bullet(Clone)"){//If enemy bullet collides with ship
            player_health -= 2;
        }
        else if(col.gameObject.name == "enemy_bullet_small" || col.gameObject.name == "enemy_bullet_small(Clone)"){//Pink Bullet
            player_health -= 1;
        }
        else if(col.gameObject.name == "enemyChaser" || col.gameObject.name == "enemyChaser(Clone)"){//Enemy Chaser
            player_health -= 8;
        }
        else if(col.gameObject.name == "vulcanBeam" || col.gameObject.name == "vulcanBeam(Clone)"){//Enemy Chaser
            player_health -= 12;
        }        
        else{
            Debug.Log("Other Collision with player");//log collision in command line
        }

        if(player_health < 0){
            player_health = 0;
        }
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
