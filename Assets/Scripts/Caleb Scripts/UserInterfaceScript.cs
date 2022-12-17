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

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        PlayButton = root.Q<Button>("PlayButton");
        SettingsButton = root.Q<Button>("SettingsButton");
        QuitButton = root.Q<Button>("QuitButton");
        MenuButton = root.Q<Button>("MenuButton");

        PlayButton.clicked += PlayButtonPressed;
        SettingsButton.clicked += SettingsButtonPressed;
    }

    void PlayButtonPressed()
    {
        SceneManager.LoadScene("main");
    }

    void SettingsButtonPressed()
    {

    }
}
