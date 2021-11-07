using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    //variables
    public float maxSpeed = 5;
    public float rSpd = 5;
    public float rotationWASD = 180;
    public Transform myTarget;
    public float x;
    public float y;
    public float z;
    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;
    public float control_number;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = spriteArray[0];
        control_number = 4;
    }

    // Update is called once per frame
    void Update()
    {
        playerMove();
    }


    void playerMove() 
    {
        if (control_number == 1)//Joystick (Key - J) 
            playerMoveJoyStick();
        else if (control_number == 2)//Mouse Follow (Key - M)
            playerMoveMouseFollow();
        else if (control_number == 3)//WASD controls (Key - U)
            playerMoveKeys();
        else if (control_number == 4)//OP controls (Key - P) //DEFAULT
            platerMoveFreeMode();
        else
            playerMoveJoyStick();
    }



    //HELPER FUNCTIONS

    //Joystick style movement (#1) - J
    void playerMoveJoyStick()
    {
        //rotational
        Quaternion rot = transform.rotation;//get ships current rotation info in rot
        z = rot.eulerAngles.z; //get the z rotation value from that
        
        //get xy input
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");


        //DIAGONAL ROTATIONS

        //Rotate TOP-RIGHT counter-clockwise
        if ((z >= 135 && z < 312.5) && ((y > 0) && (x > 0)))
            z += Math.Abs(y) * rSpd;
        //Rotate TOP-RIGHT clockwise
        else if ((z < 135 || z > 317.5) && ((y > 0) && (x > 0)))
            z -= Math.Abs(y) * rSpd;
        //Rotate BOTTOM LEFT counter-clockwise
        if ((z >= 315 || z < 132.5) && ((y < 0) && (x < 0)))
            z += Math.Abs(y) * rSpd;
        //Rotate BOTTOM-LEFT clockwise
        else if ((z < 315 && z > 137.5) && ((y < 0) && (x < 0)))
            z -= Math.Abs(y) * rSpd;
        //Rotate TOP-LEFT counter-clockwise
        if ((z >= 225 || z < 42.5) && ((y > 0) && (x < 0)))
            z += Math.Abs(y) * rSpd;
        //Rotate TOP-LEFT clockwise
        else if ((z < 225 && z > 47.5) && ((y > 0) && (x < 0)))
            z -= Math.Abs(y) * rSpd;
        //Rotate BOTTOM-RIGHT counter-clockwise
        if ((z >= 45 && z < 222.5) && ((y < 0) && (x > 0)))
            z += Math.Abs(y) * rSpd;
        //Rotate BOTTOM-RIGHT clockwise
        else if ((z < 45 || z > 227.5) && ((y < 0) && (x > 0)))
            z -= Math.Abs(y) * rSpd;

        //Perfect Direction makes sure rotation doesnt overcorrect and bounce back and forth 
        
        //PERFECT LEFT
        else if ((z >= 87.5 && z <= 92.5) && (x < 0) && (y == 0))//
            z = 90;
        //PERFECT RIGHT
        else if((z <= 272.5 && z >= 267.5) && (x > 0) && (y == 0))//
            z = 270;
        //PERFECT DOWN
        else if ((z <= 182.5 && z >= 177.5) && (y < 0) && (x == 0))//
            z = 180;
        //PERFECT UP
        else if ((z <= 2.5 && z >= 357.5) && (y > 0) && (x == 0))//
            z = 0;
        //PERFECT TOP-RIGHT
        else if ((z >= 312.5 && z <= 317.5) && (x > 0) && (y > 0))//
            z = 315;
        //PERFECT TOP-LEFT
        else if ((z <= 42.5 && z >= 47.5) && (x < 0) && (y > 0))//
            z = 45;
        //PERFECT BOTTOM-RIGHT
        else if ((z <= 222.5 && z >= 227.5) && (y < 0) && (x > 0))//
            z = 225;
        //PERFECT BOTTOM-LEFT
        else if ((z <= 132.5 && z >= 137.5) && (y < 0) && (x < 0))//
            z = 135;

        //HORTIZONTAL ROTATIONS

        //Rotate LEFT from TOP
        else if ((z < 87.5 || z > 270) && ((x < 0) && (y == 0)))//
            z += Math.Abs(x) * rSpd;
        //Rotate LEFT from DOWN
        else if ((z > 92.5 && z <= 270) && ((x < 0) && (y == 0)))//
            z -= Math.Abs(x) * rSpd;
        //Rotate RIGHT from TOP
        else if ((z < 90 || z > 272.5) && ((x > 0) && (y == 0)))//
            z -= Math.Abs(x) * rSpd;
        //Rotate RIGHT from DOWN
        else if ((z >= 90 && z < 267.5) && ((x > 0) && (y == 0)))//
            z += Math.Abs(x) * rSpd;

        //VERTICAL ROTATIONS
        //Rotate UP from LEFT
        else if ((z <= 180 && z > 2.5) && ((y > 0) && (x == 0)))//
            z -= Math.Abs(y) * rSpd;
        //Rotate UP from RIGHT
        else if ((z < 357.5 && z > 180) && ((y > 0) && (x == 0)))//
            z += Math.Abs(y) * rSpd;
        //Rotate DOWN from LEFT
        else if ((z >= 0 && z < 177.5) && ((y < 0) && (x == 0)))//
            z += Math.Abs(y) * rSpd;
        //Rotate DOWN from RIGHT
        else if ((z < 360 && z > 182.5) && ((y < 0) && (x == 0)))//
            z -= Math.Abs(y) * rSpd;

        //Set the rotations
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        //Check for boost
        if (Input.GetKey(KeyCode.LeftShift))
            maxSpeed = 10;
        else
            maxSpeed = 5;


        //Ship Movement
        Vector3 pos = transform.position;

        //create direction vectors based on xy input
        Vector3 velocityVertical = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        Vector3 velocityHorizontal = new Vector3(0, Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime,  0);
        Vector3 velocityDiagonal = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);

        //ove in given direction
        if ((x == 0) && (y > 0))
            pos += rot * velocityVertical;
        else if ((x == 0) && (y < 0))
            pos -= rot * velocityVertical;
        else if ((y == 0) && (x > 0))
            pos += rot * velocityHorizontal;
        else if ((y == 0) && (x < 0))
            pos -= rot * velocityHorizontal;
        else if ((y > 0) && (x > 0))
            pos += rot * velocityDiagonal;
        else if ((y > 0) && (x < 0))
            pos += rot * velocityDiagonal;
        else if ((y < 0) && (x > 0))
            pos -= rot * velocityDiagonal;
        else if ((y < 0) && (x < 0))
            pos -= rot * velocityDiagonal;

        transform.position = pos;

        //Set the Skin of the Ship
        if (Input.GetKey(KeyCode.LeftShift) && (y != 0 || x != 0))//if pressing space, boost
            spriteRenderer.sprite = spriteArray[1];
        else if ((y != 0 || x != 0))
            spriteRenderer.sprite = spriteArray[0];//normal exhaust
        else
            spriteRenderer.sprite = spriteArray[2];//idle

        //Check to see if controls are changed
        if (Input.GetKeyDown("m"))
            control_number = 2;
        else if (Input.GetKeyDown("u"))
            control_number = 3;
        else if (Input.GetKeyDown("p"))
            control_number = 4;
    }


    //Mouse follow style movement (#2) - M
    void playerMoveMouseFollow()
    {
        //Rotate towards the mouse
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;

        //Check for boost
        if (Input.GetKey(KeyCode.LeftShift))
            maxSpeed = 10;
        else
            maxSpeed = 5;


        //Ship movement
        Quaternion rot = transform.rotation;
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += rot * velocity;
        transform.position = pos;

        //Set the Skin of the Ship
        y = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift) && (y > 0))//if pressing space, boost
            spriteRenderer.sprite = spriteArray[1];
        else if((y > 0))
            spriteRenderer.sprite = spriteArray[0];//normal exhaust
        else
            spriteRenderer.sprite = spriteArray[2];//idle

        //Check to see if controls are changed
        if (Input.GetKeyDown("j"))
            control_number = 1;
        else if (Input.GetKeyDown("u"))
            control_number = 3;
        else if (Input.GetKeyDown("p"))
            control_number = 4;
    }


    //WASD Key style movement (#3) - U
    void playerMoveKeys()
    {
        //Ship Rotation
        Quaternion rot = transform.rotation;
        z = rot.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotationWASD * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        //Check for boost
        if (Input.GetKey(KeyCode.LeftShift))
            maxSpeed = 10;
        else
            maxSpeed = 5;

        //Ship movement
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += rot * velocity;
        transform.position = pos;

        //Set the Skin of the Ship
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        //Set the Skin of the Ship
        if (Input.GetKey(KeyCode.LeftShift) && (y != 0 || x != 0))//if pressing space, boost
            spriteRenderer.sprite = spriteArray[1];
        else if ((y != 0 || x != 0))
            spriteRenderer.sprite = spriteArray[0];//normal exhaust
        else
            spriteRenderer.sprite = spriteArray[2];//idle

        //Check to see if controls are changed
        if (Input.GetKeyDown("m"))
            control_number = 2;
        else if (Input.GetKeyDown("j"))
            control_number = 1;
        else if (Input.GetKeyDown("p"))
            control_number = 4;
    }


    //Free Mode (WASD movement and Mouse for rotation) (#4) - P
    void platerMoveFreeMode()
    {
        //Ship Movement
        Vector3 pos = transform.position;
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        //Rotate towards the mouse
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;

        //Check for boost
        if (Input.GetKey(KeyCode.LeftShift))
            maxSpeed = 10;
        else
            maxSpeed = 5;

        //create direction vectors based on xy input
        Vector3 velocityVertical = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        Vector3 velocityHorizontal = new Vector3(Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime, 0, 0);

        //move in given direction
        if (x > 0)
            pos += velocityHorizontal;
        else if(x < 0)
            pos += velocityHorizontal;
        if (y > 0)
            pos += velocityVertical;
        else if (y < 0)
            pos += velocityVertical;

        transform.position = pos;

        //Set the Skin of the Ship
        if (Input.GetKey(KeyCode.LeftShift) && (y != 0 || x != 0))//if pressing space, boost
            spriteRenderer.sprite = spriteArray[1];
        else if ((y != 0 || x != 0))
            spriteRenderer.sprite = spriteArray[0];//normal exhaust
        else
            spriteRenderer.sprite = spriteArray[2];//idle

        //Check to see if controls are changed
        if (Input.GetKeyDown("m"))
            control_number = 2;
        else if (Input.GetKeyDown("u"))
            control_number = 3;
        else if (Input.GetKeyDown("j"))
            control_number = 1;
    }


}
