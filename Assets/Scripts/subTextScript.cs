using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class subTextScript : MonoBehaviour
{
    Text textSub;

    // Start is called before the first frame update
    void Start()
    {
        textSub = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textSub.text = GAMEFLOW.textSub;
        // Color color = textSub.color;
        // color.a = GAMEFLOW.alpha;
        // textSub.color = color;
        // Debug.Log("A: " + textSub.color.a + " B: " + GAMEFLOW.alpha + " C: " + color.a);

        // Color z = textSub.color;
        // Debug.Log("Cur: " + z.a + "New: " + GAMEFLOW.alpha + " Z: " + textSub.color.z);
        // z.a = GAMEFLOW.alpha;
        // textSub.color = z;
    }
}
