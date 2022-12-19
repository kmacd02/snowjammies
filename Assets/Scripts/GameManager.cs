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
    [SerializeField] private float fullGameTime = 120f; // 60 seconds for a full game
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

    private float timer = 60;
    [SerializeField] private Slider momTimer;
    private bool stopTimer = false;


    //[SerializeField] private float fadeSpeed = 1.0f;

    //Array of sprites for gameover screens
    //Numbered based on the numbering in the GDD
    //[SerializeField] private Sprite[] bgs;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = playerInputObject.GetComponent<PlayerInput>();
        status = 0;
        StartCoroutine(FullGame()); // full game time
        audio.PlayBGMWithoutLoop(0);

        flavorTextNum = 15;
        StartCoroutine((showFlavorText()));

        momTimer.maxValue = fullGameTime;
        momTimer.value = timer;
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
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            stopTimer = true;
        }

        if (!stopTimer)
        {
            momTimer.value = timer;
        }

        switch(status)
        {
            case 0: //continue
                break;
            case 1: //win or fail
                //TODO: set gameoverscreen sprite/image

                //bgNum =

                //gameoverscreen.SetActive(true);
                //gameOverBG.sprite = bgs[0];
                StartCoroutine((showFlavorText()));
                break;
            case 2: //neutral
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
        Debug.Log("fullGameTime: complete");

        GameOverManager.bgNum = 7;
        SceneManager.LoadScene("EndGame");
        //Display gameover screen
        //SceneManager.LoadScene("EndScreen");
        // gameoverscreen.SetActive(true);
        // gameOverBG.sprite = bgs[0];
    }
    private IEnumerator showFlavorText()
    {
        //pause mom timer
        stopTimer = true;
        //disable player movement
        playerInput.enabled = false;
        FlavorTextScreen.SetActive(true);
        flavorTextBG.sprite = flavorTexts[flavorTextNum];
        yield return new WaitForSeconds(textShowTime);
        playerInput.enabled = true;
        stopTimer = false;

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