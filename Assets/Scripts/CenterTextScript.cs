using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenterTextScript : MonoBehaviour
{
    Text textCenter;

    // Start is called before the first frame update
    void Start()
    {
        textCenter = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textCenter.text = GAMEFLOW.centerText;
    }
}
