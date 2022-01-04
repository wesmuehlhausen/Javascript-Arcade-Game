using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructCleaner : MonoBehaviour
{
    public float despawnTimer = 5;
    public GameObject explosionPrefab;//Explosion of this ship

    // Update is called once per frame
    void Update()
    {
        despawnTimer -= Time.deltaTime;
        if (despawnTimer <= 0){
            if(explosionPrefab){
                if(gameObject.name == "lightMine" || gameObject.name == "lightMine(Clone)"){
                    Instantiate(explosionPrefab, transform.position, transform.rotation);
                }
            }
            Destroy(gameObject);
        }
            
    }
}
