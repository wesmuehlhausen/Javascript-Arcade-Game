using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProbeMovement : MonoBehaviour
{
    public float topSpeed = 3f;
    public float movementSpeed = 0f;
    public float distance;
    public float stopAt = 4;
    public float acceleration = 0.1f;
    public bool stalking = true;
    public float opac = 1.0f;
    public float minOpac = 0.05f;

    Transform player;
    GameObject gameObj;
    

    //public Sprite[] spriteArray;
    //public SpriteRenderer spriteRenderer;

    void Start()
    {
        //spriteRenderer.sprite = spriteArray[0];
        gameObj = GameObject.Find("ship_normal");
    }

    void Update()
    {

        //Try to find the ship
        if (gameObj == null)
            gameObj = GameObject.Find("ship_normal");

        //Find where the player ship is
        distance = Vector3.Distance(gameObj.transform.position, transform.position);

        //State 1: Creep towards ship with invisibility on
        if (stalking == true)
        {
            //Change the visibility to become dimmer
            if (opac > minOpac)
            {
                Color tmp = GetComponent<SpriteRenderer>().color;
                opac -= .005f;
                tmp.a = opac;
                GetComponent<SpriteRenderer>().color = tmp;
            }
            else if (opac < minOpac)
            {
                Color tmp = GetComponent<SpriteRenderer>().color;
                opac = minOpac;
                tmp.a = opac;
                GetComponent<SpriteRenderer>().color = tmp;
            }


            //If far away, move towards ship
            if (distance > stopAt)
            {
                //if over the top speed, adjust
                if (movementSpeed > topSpeed)
                {
                    movementSpeed = topSpeed;
                }
                //if under the top speed, accelerate
                else if (movementSpeed < topSpeed)
                {
                    movementSpeed += acceleration;
                }
                //spriteRenderer.sprite = spriteArray[1];

                //move towards ship
                Vector3 shipPos = transform.position;
                Vector3 shipVelocity = new Vector3(0, movementSpeed * Time.deltaTime, 0);
                shipPos += transform.rotation * shipVelocity;
                transform.position = shipPos;

            }
            //if close to ship, move away from ship
            else
            {
                //spriteRenderer.sprite = spriteArray[0];
                Vector3 shipPos = transform.position;
                if (movementSpeed > 0)
                    movementSpeed -= acceleration;
                else if (movementSpeed < 0)
                    movementSpeed = 0f;

                Vector3 shipVelocity = new Vector3(0, movementSpeed * Time.deltaTime, 0);
                shipPos += transform.rotation * shipVelocity;
                transform.position = shipPos;
            }
        }
        else//State 2: After shot, invisibility off and go in opposite direction
        {
            //Make completely visible
            Color tmp = GetComponent<SpriteRenderer>().color;
            opac = 1f;
            tmp.a = opac;
            GetComponent<SpriteRenderer>().color = tmp;

            //if over the top speed, adjust
            if (movementSpeed > topSpeed)
            {
                movementSpeed = topSpeed;
            }
            //if under the top speed, accelerate
            else if (movementSpeed < topSpeed)
            {
                movementSpeed += acceleration;
            }
            //spriteRenderer.sprite = spriteArray[1];

            //move towards ship
            Vector3 shipPos = transform.position;
            Vector3 shipVelocity = new Vector3(0, movementSpeed * Time.deltaTime, 0);
            shipPos += transform.rotation * shipVelocity;
            transform.position = shipPos;
        }







    }

}
