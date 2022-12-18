using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class UserInterfaceScript : MonoBehaviour
{
    public Button PlayButton;
    public Button SettingsButton;
    public Button QuitButton;
    public Button MenuButton;
    public Button HowToButton;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        PlayButton = root.Q<Button>("PlayButton");
        SettingsButton = root.Q<Button>("SettingsButton");
        QuitButton = root.Q<Button>("QuitButton");
        MenuButton = root.Q<Button>("MenuButton");
        HowToButton = root.Q<Button>("HowToButton");

        PlayButton.clicked += PlayButtonPressed;
        //SettingsButton.clicked += SettingsButtonPressed;
        //HowToButton.clicked += HowToButtonPressed;
        QuitButton.clicked += ExitGame;
    }

    void PlayButtonPressed()
    {
        SceneManager.LoadScene("Main");
    }

    //void SettingsButtonPressed()
    //{
        
    //}

    //void HowToButtonPressed()
    //{

    //}
    
    void ExitGame()
    {
        Application.Quit();
    }
}
