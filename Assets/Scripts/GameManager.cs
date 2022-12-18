using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{
    [SerializeField] private float fullGameTime = 60f; // 60 seconds for a full game
    [SerializeField] private float textShowTime = 4f;
    [SerializeField] SimpleAudioManager audio;

    public int status; //0 = continue, 1 = win/fail, 2 = neutral
    public int flavorTextNum = 0;


    [SerializeField] GameObject gameoverscreen;
    [SerializeField] GameObject playerInputObject;
    [SerializeField] GameObject FlavorTextScreen;

    private PlayerInput playerInput;
    
    [SerializeField] Image flavorTextBG;

    [SerializeField] private Sprite[] flavorTexts;


    //[SerializeField] private float fadeSpeed = 1.0f;
    //TODO: Add array of sprites for gameover screens

    // Start is called before the first frame update
    void Start()
    {
        playerInput = playerInputObject.GetComponent<PlayerInput>();
        status = 0;
        StartCoroutine(FullGame()); // full game time
        audio.PlayBGMWithoutLoop(0);

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
                //gameoverscreen.SetActive(true);
                //gameOverBG.sprite = bgs[0];
                StartCoroutine((showFlavorText()));
                break;
            case 2: //neutral
                //gameoverscreen.SetActive(true);
                //TODO: cut to flavortext (coroutine, also disable player input)
                StartCoroutine((showFlavorText()));
                status = 0;
                break;
            default: //error
                Debug.Log("Invalid game status. Must be 0, 1, or 2.");
                break;
        }
    }

    private IEnumerator FullGame()
    {
        yield return new WaitForSeconds(fullGameTime); // full game

        //Display gameover screen
        //SceneManager.LoadScene("EndScreen");
        // gameoverscreen.SetActive(true);
        // gameOverBG.sprite = bgs[0];
    }
    private IEnumerator showFlavorText()
    {
        //disable player movement
        playerInput.enabled = false;
        FlavorTextScreen.SetActive(true);
        flavorTextBG.sprite = flavorTexts[flavorTextNum];
        yield return new WaitForSeconds(textShowTime);
        playerInput.enabled = true;
        if (status == 1)
        {
            SceneManager.LoadScene("EndGame");
        }
        else
        {
            FlavorTextScreen.SetActive(false);
        }        
    }
}