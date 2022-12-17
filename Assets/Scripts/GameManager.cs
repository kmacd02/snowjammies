using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int status; //0 = continue, 1 = win/fail, 2 = neutral
    [SerializeField] GameObject gameoverscreen;
    [SerializeField] Image gameOverBG;

    [SerializeField] private Sprite[] bgs;
    //TODO: Add array of sprites for gameover screens

    // Start is called before the first frame update
    void Start()
    {
        status = 0;
    }

    public void restartGame()
    {
        status = 0;
        //TODO: reset all locations and whatnot
        gameoverscreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch(status)
        {
            case 0: //continue
                break;
            case 1: //win or fail
                //TODO: set gameoverscreen sprite/image
                gameoverscreen.SetActive(true);
                gameOverBG.sprite = bgs[0];
                break;
            case 2: //neutral
                gameoverscreen.SetActive(true);
                gameOverBG.sprite = bgs[1];
                break;
            default: //error
                Debug.Log("Invalid game status. Must be 0, 1, 2, or 3.");
                break;
        }
    }
}