using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GAMEFLOW : MonoBehaviour
{
    public static int level = 0;
    public static int step = 0;
    public static string centerText;
    public static string textSub;
    public static int enemiesAlive = 0;
    public static float[] depths = {-49.4f};
    public static bool[] wasdCheck = {false, false, false, false};
    public static bool spawnedDummies;
    public static bool tmp;
    bool spawned = false;
    public static float timer = 0;
    public static float alpha = 1f;
    private float direction = 1f;

    

    Vector3 position;

    public GameObject player;
    public GameObject cruiserPrefab;
    public GameObject dummyCruiser;
    public GameObject respawnPrefab;

    // Start is called before the first frame update
    void Start()
    {
        level = 0;//TODO change back to level 1
        centerText = "";
        textSub = "";
        player = GameObject.Find("ship_normal");
        spawnedDummies = false;
        timer = 0;
        tmp = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(player == null){
            centerText = "Game Over";
        }


        timer += Time.deltaTime;
        //Debug.Log(timer.ToString());
        if(timer > 10000)
            timer = 1000;

        //Put Ship back at 0,0 if out of bounds
        //if x < -85, x > 85, y < -85, y > 85
        if((player.transform.position.x < -85 || player.transform.position.x > 85) || (player.transform.position.y < -85 || player.transform.position.y > 85)){
            spawnPlayerAtOrigin();
        }

        //Tutorial
        if(level == 0){

            //To skip, press V
            if(Input.GetKeyDown("v") || Input.GetKeyDown("v")){
                step = 5;
                timer = 0;
            }

            //Step 0: Title screen
            if(step == 0){
                centerText = "Deeep Space (Beta)";

                if(tmp == false){
                    if((int)timer % 2 == 0)//every 2 seconds
                        textSub = "Click anywhere to start (Press V to skip tutorial)";
                    else
                        textSub = "";
                    if(Input.GetMouseButtonDown(0)){
                        tmp = true;
                        timer = 0;
                    }
                }
                else{
                    int intVersion = 5 - (int)timer;
                    if(intVersion <= 0) 
                        step = 1;
                    textSub = "BLAST OF IN " + intVersion;
                }
            }

            //step 1: test out WASD
            else if(step == 1){
                centerText = "Controls: Movement (1/4)";
                textSub = "Press [WASD] keys to fly around";
                if((wasdCheck[0] && wasdCheck[1]) && (wasdCheck[2] && wasdCheck[3])){//if they have pressed WASD
                    step = 2;
                    timer = 0;
                }
                if(Input.GetKeyDown("w"))
                    wasdCheck[0] = true;
                else if(Input.GetKeyDown("a"))
                    wasdCheck[1] = true;
                else if(Input.GetKeyDown("s"))
                    wasdCheck[2] = true;
                else if(Input.GetKeyDown("d"))
                    wasdCheck[3] = true;
            
            }

            //Step 2: Boost
            else if(step == 2){
                centerText = "Controls: Booster (2/4)";
                textSub = "Now, hold [SHIFT] while moving with [WASD] to boost";
                if(timer > 5){
                        step = 3;
                }
            }

            //Step 3: Shooting
            else if(step == 3){
                centerText = "Controls: Shooting (3/4)";
                textSub = "Use the [MOUSE] to aim and press [SPACE] to fire at enemies";
                if(spawnedDummies == false){
                    spawnPlayerAtOrigin();//Spawn Ship at 0,0
                    spawnShip(dummyCruiser, 4f, 3f, depths[0]);
                    spawnShip(dummyCruiser, -4f, 3f, depths[0]);
                    spawnShip(dummyCruiser, 4f, -3f, depths[0]);
                    spawnShip(dummyCruiser, -4f, -3f, depths[0]);             
                    spawnedDummies = true;       
                }
                if(spawnedDummies == true && enemiesAlive == 0){//If all of the enemies are destroyed
                    step = 4;
                    spawnedDummies = false;
                }
            }

            //Step 4: Drop a mine
            else if(step == 4){
                Debug.Log(timer);
                Debug.Log(wasdCheck[0]);
                centerText = "Controls: Mine (4/4)";
                textSub = "Press [E] to drop a mine";
                if(spawnedDummies == false){
                    spawnPlayerAtOrigin();//Spawn Ship at 0,0
                    spawnShip(dummyCruiser, 2f, 0f, depths[0]);          
                    spawnedDummies = true;   
                    timer = 0;    
                    wasdCheck[0] = false;
                }
                else if(Input.GetKeyDown("e")){
                    wasdCheck[0] = true;
                }
                if(timer > 5 && wasdCheck[0] == true){
                    step = 5;
                    timer = 0;
                }
                    
            }

            //Step 5: Countdown to the game
            else if(step == 5){
                if(timer < 10){
                    centerText = (10 - (int)timer) + "";
                    textSub = "First wave of enemies spawning in: ";
                }
                else{
                    centerText = "";
                    textSub = "";
                    spawnPlayerAtOrigin();
                    step = 6;
                    level = 1;
                    timer = 0;
                }
            }
            

        }

        //Level 1 - (4 enemy cruisers)
        else if(level == 1)
        {
            if( timer < 2){
                    centerText = "Level 1";
                    textSub = "";
            }
            else{
                centerText = "";
            }

            //If there are no enemeies are spawned yet, spawn them. 
            if (spawned == false && timer > 3) {
                //Create the ships for the first level add to number of ships
                enemiesAlive = 0;
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
                timer = 0;
            }
        }

        //Level 2
        else if (level == 2) {

            //Create Text fo level
            if( timer < 2){
                    centerText = "Level 2";
                    textSub = "";
            }            
            else{
                centerText = "";
            }

            //If there are no enemeies are spawned yet, spawn them. 
            if (spawned == false)
            {
                if(timer > 3){
                    for (int i = 0; i < 10; ++i)
                        spawnShipRandomLocation(cruiserPrefab, -50f, 50f, -50f, 50f, depths[0]);
                    spawned = true;                    
                }
                //Create the ships for the first level add to number of ships

            }

            //If there are no enemies left, round over, change round number
            if (spawned == true && enemiesAlive == 0)
            {
                level = 3;
                spawned = false;
                timer = 0;
                centerText = "";
            }
        }

        //TODO: Add spaces between rounds
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

    void spawnPlayerAtOrigin(){
            Vector3 resetPosition = new Vector3(0, 0, -50);
            player.transform.position = resetPosition;
            Vector3 resetPosition2 = new Vector3(0, 0, -51);
            Instantiate(respawnPrefab, resetPosition2, Quaternion.Euler(0, 0, 0));
    }

    void spawnShipRandomLocation(GameObject prefab, float xCorMin, float xCorMax, float yCorMin, float yCorMax, float zCor)
    {
        position = new Vector3(Random.Range(xCorMin, xCorMax), Random.Range(yCorMin, yCorMax), zCor);
        Instantiate(prefab, position, Quaternion.Euler(0, 0, 0));
        enemiesAlive++;
    }
}
