using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class UserInterfaceScript : MonoBehaviour
{
    [Header("How To")]
    [SerializeField]
    private VisualTreeAsset HowToMenu;
    private VisualElement Tutorial;


    private UIDocument doc;
    public Button PlayButton;
    public Button OptionsButton;
    public Button QuitButton;
    public Button MenuButton;
    public Button HowToButton;


    private VisualElement Container;
    private VisualElement HowToWrapper;
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        Container = root.Q<VisualElement>("Container");
        HowToWrapper = root.Q<VisualElement>("HowToWrapper");


        // Gathering Button Roots

        PlayButton = root.Q<Button>("PlayButton");
        OptionsButton = root.Q<Button>("OptionsButton");
        QuitButton = root.Q<Button>("QuitButton");
        MenuButton = root.Q<Button>("MenuButton");
        HowToButton = root.Q<Button>("HowToButton");


        Tutorial = HowToMenu.CloneTree();
        var BackButton = Tutorial.Q<Button>("BackButton");


        PlayButton.clicked += PlayGame;
        //OptionsButton.clicked += SettingsMenu;
        QuitButton.clicked += ExitGame;
        BackButton.clicked += BackButtonClicked;
        HowToButton.clicked += DisplayTutorial;
    }

    void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

    void DisplayTutorial()
    {
        Container.Clear();
        Container.Add(Tutorial);
    }

    void BackButtonClicked()
    {
        Container.Clear();
        Container.Add(PlayButton);
        Container.Add(OptionsButton);
        Container.Add(HowToButton);
        Container.Add(QuitButton);
    }

    //void HowToButtonPressed()
    //{

    //}

    void ExitGame()
    {
        Application.Quit();
    }


}
