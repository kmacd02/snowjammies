using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameOverManager : MonoBehaviour
{
    public static int bgNum = 0;

    public static float BGMVol = 0.5f;

    [SerializeField] private Sprite[] bgs;

    [SerializeField] GameObject credits;
    //I declared this in GameManager and made it public.

    [SerializeField] Image gameOverBG;
    [SerializeField] SimpleAudioManager audio;

    void Start()
    {
        Debug.Log(bgNum);
        gameOverBG.sprite = bgs[bgNum];
        if (bgNum == 0 || bgNum == 6)
        {
            audio.PlayBGMWithLoop(1);
        }
        else
        {
            audio.PlayBGMWithLoop(2);
        }
    }

    public void restart()
    {
        SceneManager.LoadScene("AnviTestScene");
    }

    public void toMainMenu()
    {
        StartCoroutine(showCredits());
    }

    private IEnumerator showCredits()
    {
        credits.SetActive(true);
        yield return new WaitForSeconds(4f);        
        SceneManager.LoadScene("TitleScreen");
        credits.SetActive(false);
    }
}
