using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    public static int total = 0;
    Text score;
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        total = (int)timer + scoreValue;
        score.text = "Score: " + total;
    }
}
