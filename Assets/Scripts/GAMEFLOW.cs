using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEFLOW : MonoBehaviour
{
    public int level = 0;
    bool complete = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (level == 0)
        {
            //
        }
        else if (level == 0 && complete == true)
        {
            complete = false;
        }
    }
}
