using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int status; //0 = continue, 1 = win, 2 = neutral, 3 = fail

    // Start is called before the first frame update
    void Start()
    {
        status = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch(status)
        {
            case 0: //continue
                break;
            case 1: //win
                break;
            case 2: //neutral
                break;
            case 3: //fail
                break;
            default: //error
                Debug.Log("Invalid game status. Must be 0, 1, 2, or 3.");
                break;
        }
    }
}
