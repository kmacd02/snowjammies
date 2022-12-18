using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Diagnostics;
//using System.Diagnostics;

public class UserInterfaceScript : MonoBehaviour
{


    // Adding Headers to UIDocument
    [Header("How To")]
    [SerializeField]
    private VisualTreeAsset HowToMenu;
    private VisualElement Tutorial;
    
    [Header("UI Volume Control")]
    [SerializeField]
    private VisualTreeAsset VolumeMenu;
    private VisualElement VolumeStuff;

    // Initializing Main Menu Buttons
    private UIDocument doc;
    public Button PlayButton;
    public Button OptionsButton;
    public Button QuitButton;
    public Button MenuButton;
    public Button HowToButton;

    float test2;
    public Slider MasterVol;
    public Slider BGMVol;
    public Slider SFXVol;

    // Initializing VisualElements in .uxml files
    private VisualElement Container;
    //private VisualElement HowToWrapper;
    //private VisualElement VolumePanel;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        Container = root.Q<VisualElement>("Container");
        //HowToWrapper = root.Q<VisualElement>("HowToWrapper");
        

        // Gathering Button Roots

        PlayButton = root.Q<Button>("PlayButton");
        OptionsButton = root.Q<Button>("OptionsButton");
        QuitButton = root.Q<Button>("QuitButton");
        MenuButton = root.Q<Button>("MenuButton");
        HowToButton = root.Q<Button>("HowToButton");


        Tutorial = HowToMenu.CloneTree();
        var BackButton = Tutorial.Q<Button>("BackButton");

        VolumeStuff = VolumeMenu.CloneTree();
        var BackVolume = VolumeStuff.Q<Button>("BackVolume");

        //VolumeStuff = VolumeMenu.CloneTree();
        //MasterVol = VolumeStuff.Q<Slider>("MasterVolSlider");
        //BGMVol = VolumeStuff.Q<Slider>("BGMSlider");
        //SFXVol = VolumeStuff.Q<Slider>("SFXSlider");

        PlayButton.clicked += PlayGame;
        OptionsButton.clicked += VolumeSettings;
        QuitButton.clicked += ExitGame;
        BackButton.clicked += BackButtonClicked;
        HowToButton.clicked += DisplayTutorial;
        BackVolume.clicked += BackButtonClicked;

        //test2 = MasterVol.value;

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

    void VolumeSettings()
    {
        Container.Clear();
        Container.Add(VolumeStuff);

    }

    void ExitGame()
    {
        Application.Quit();
        UnityEngine.Debug.Log("Quit.");
    }


}
