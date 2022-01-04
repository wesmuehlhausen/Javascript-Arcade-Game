using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GAMEFLOW : MonoBehaviour
{
    public static int level = 0;
    public static string centerText;
    public static int enemiesAlive = 0;
    public static float[] depths = {-49.4f};
    bool spawned = false;
    Vector3 position;

    public GameObject player;
    public GameObject cruiserPrefab;

    // Start is called before the first frame update
    void Start()
    {
        level = 99;//TODO change back to level 1
        centerText = "";
        player = GameObject.Find("ship_normal");
    }

    // Update is called once per frame
    void Update()
    {
        //Tutorial
        if(level == 0){

        }

        //Level 1 - (4 enemy cruisers)
        else if(level == 1)
        {
            //If there are no enemeies are spawned yet, spawn them. 
            if (spawned == false) {
                //Create the ships for the first level add to number of ships
                spawnShip(cruiserPrefab, 10f, 10f, depths[0]);
                spawnShip(cruiserPrefab, 10f, -10f, depths[0]);
                spawnShip(cruiserPrefab, -10f, 10f, depths[0]);
                spawnShip(cruiserPrefab, -10f, -10f, depths[0]);
                spawned = true;
            }

            //If there are no enemies left, round over, change round number
            if (spawned == true && enemiesAlive == 0) {
                level = 2;
                spawned = false;
            }
        }

        //Level 2
        else if (level == 2) {
            //If there are no enemeies are spawned yet, spawn them. 
            if (spawned == false)
            {
                //Create the ships for the first level add to number of ships
                for (int i = 0; i < 10; ++i)
                    spawnShipRandomLocation(cruiserPrefab, -50f, 50f, -50f, 50f, depths[0]);
                spawned = true;
            }

            //If there are no enemies left, round over, change round number
            if (spawned == true && enemiesAlive == 0)
            {
                level = 3;
                spawned = false;
            }
        }

        //Level 3: 5 chasers 
        //Level 4: 3 chasers and 5 cruisers
        //Level 5: 3 probes 
        //Level 6: 3 chasers, 3 probes, 3 cruisers
        //Level 7: 1 Vulcan
        //Level 8: 2 Vulcans, 2 chasers, 5 cruisers
        //Level 9: 5 Vulcans
        //Level 10: 1 Mothership
        //UFO's later
    }

    void spawnShip(GameObject prefab, float xCor, float yCor, float zCor) {
        position = new Vector3(xCor, yCor, zCor);
        Instantiate(prefab, position, Quaternion.Euler(0, 0, 0));
        enemiesAlive++;
    }

    void spawnShipRandomLocation(GameObject prefab, float xCorMin, float xCorMax, float yCorMin, float yCorMax, float zCor)
    {
        position = new Vector3(Random.Range(xCorMin, xCorMax), Random.Range(yCorMin, yCorMax), zCor);
        Instantiate(prefab, position, Quaternion.Euler(0, 0, 0));
        enemiesAlive++;
    }
}
