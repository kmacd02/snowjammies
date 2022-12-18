using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class UserInterfaceScript : MonoBehaviour
{
    public Button PlayButton;
    public Button OptionsButton;
    public Button QuitButton;
    public Button MenuButton;
    public Button HowToButton;

    private VisualElement Container;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        Container = root.Q<VisualElement>("Container");
        
        // Gathering Button Roots

        PlayButton = root.Q<Button>("PlayButton");
        OptionsButton = root.Q<Button>("OptionsButton");
        QuitButton = root.Q<Button>("QuitButton");
        MenuButton = root.Q<Button>("MenuButton");
        HowToButton = root.Q<Button>("HowToButton");



        PlayButton.clicked += PlayGame;
        OptionsButton.clicked += SettingsMenu;
        //HowToButton.clicked += HowToButtonPressed;
        QuitButton.clicked += ExitGame;
    }

    void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

    void SettingsMenu()
    {
        Container.Clear();
    }

    //void HowToButtonPressed()
    //{

    //}

    void ExitGame()
    {
        Application.Quit();
    }
}
