using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedByShip : MonoBehaviour
{
    public int health = 1;
    //public int damageGiven = 0;
    public int pointsOnDeath = 0;
    public GameObject explosionPrefab;//Explosion of this ship
    public bool isShip = false;

    //On ship collision/trigger
    void OnTriggerEnter2D(Collider2D col) 
    {
        if(isShip == false){//If this is a bullet
            health = 0;
        }
        else{//If this is a ship
                if(col.gameObject.name == "bullet_pink" || col.gameObject.name == "bullet_pink(Clone)"){
                    health -= 1;
                }
                else if(gameObject.name == "enemyChaser" || gameObject.name == "enemyChaser(Clone)"){
                    if(col.gameObject.name == "ship_normal"){
                        health = 0;//Explode
                    }
                }
                else{
                    Debug.Log("Other collision");
                }
        }
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
