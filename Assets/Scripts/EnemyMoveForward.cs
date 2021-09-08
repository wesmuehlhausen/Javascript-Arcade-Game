using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveForward : MonoBehaviour
{
    public float topSpeed = 3f;
    public float movementSpeed = 0f;
    public float distance;
    public float stopAt = 4;
    public float acceleration = 0.1f;
    Transform player;
    GameObject gameObj;

    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer.sprite = spriteArray[0];
        gameObj = GameObject.Find("ship_normal");
    }

    void Update()
    {
        //Try to find the ship
        if(gameObj == null)
            gameObj = GameObject.Find("ship_normal");


        distance = Vector3.Distance(gameObj.transform.position, transform.position);
        if (distance > stopAt)
        {
            if (movementSpeed > topSpeed)
            {
                movementSpeed = topSpeed;
            }
            else if (movementSpeed < topSpeed)
            {
                movementSpeed += acceleration;
            }     
            spriteRenderer.sprite = spriteArray[1];
            Vector3 shipPos = transform.position;
            Vector3 shipVelocity = new Vector3(0, movementSpeed * Time.deltaTime, 0);
            shipPos += transform.rotation * shipVelocity;
            transform.position = shipPos;

        }
        else
        {
            spriteRenderer.sprite = spriteArray[0];
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

}
