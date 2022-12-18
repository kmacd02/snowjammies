using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static int bgNum = 0;
    //public static int BGMNum = 0;

    public static float BGMVol = 0.5f;

    [SerializeField] private Sprite[] bgs;
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
        SceneManager.LoadScene("TitleScreen");
    }
}
