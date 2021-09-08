using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSprites : MonoBehaviour
{

    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;
    bool skin1 = true;
    float skinTimer = 0;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = spriteArray[0];
    }

    // Update is called once per frame
    void Update()
    {
        toggleSkins();
    }

    void toggleSkins()
    {
        skinTimer += 1;
        if (skinTimer > 30)
        {
            skinTimer = 0;
            if (skin1)
            {
                spriteRenderer.sprite = spriteArray[0];
                skin1 = false;
            }
            else
            {
                spriteRenderer.sprite = spriteArray[1];
                skin1 = true;
            }
               
        }
    }
}
