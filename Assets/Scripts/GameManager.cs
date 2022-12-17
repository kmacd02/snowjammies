using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int status; //0 = continue, 1 = win, 2 = neutral, 3 = fail

    //TODO: Add array of sprites for gameover screens

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
            case 1: //win or fail
                break;
            case 2: //neutral
                break;
            default: //error
                Debug.Log("Invalid game status. Must be 0, 1, 2, or 3.");
                break;
        }
    }
}