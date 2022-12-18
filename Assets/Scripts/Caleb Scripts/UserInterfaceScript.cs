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

    [SerializeField] AudioSource BGM_Source;
    [SerializeField] AudioSource SFX_Source;

    // Initializing Main Menu Buttons
    private UIDocument doc;
    public Button PlayButton;
    public Button OptionsButton;
    public Button QuitButton;
    public Button MenuButton;
    public Button HowToButton;

    public Slider MasterVol;
    public Slider BGMVol;
    public Slider SFXVol;

    public float mVol;
    public float bVol;
    public float sVol;

    //public float mVolOld;
    //public float bVolOld;
    //public float sVolOld;


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
        MasterVol = VolumeStuff.Q<Slider>("MasterCtrl");
        BGMVol = VolumeStuff.Q<Slider>("BGMCtrl");
        SFXVol = VolumeStuff.Q<Slider>("SFXCtrl");

        PlayButton.clicked += PlayGame;
        OptionsButton.clicked += VolumeSettings;
        QuitButton.clicked += ExitGame;
        BackButton.clicked += BackButtonClicked;
        HowToButton.clicked += DisplayTutorial;
        BackVolume.clicked += BackButtonClicked;

        mVol = MasterVol.value;
        bVol = BGMVol.value;
        sVol = SFXVol.value;

        //mVolOld = mVol;
        //bVolOld = bVol;
        //sVolOld = sVol;
        //UnityEngine.Debug.Log(mVol);
        //UnityEngine.Debug.Log(bVol);
        //UnityEngine.Debug.Log(sVol);

    }
    void Update()
    {
        mVol = MasterVol.value;
        bVol = BGMVol.value;
        sVol = SFXVol.value;
    }

    void PlayGame()
    {
        SFX_Source.Play();
        SceneManager.LoadScene("AnviTestScene");
    }

    void DisplayTutorial()
    {
        SFX_Source.Play();
        Container.Clear();
        Container.Add(Tutorial);
    }

    void BackButtonClicked()
    {
        SFX_Source.Play();
        Container.Clear();
        Container.Add(PlayButton);
        Container.Add(OptionsButton);
        Container.Add(HowToButton);
        Container.Add(QuitButton);
    }

    void VolumeSettings()
    {
        SFX_Source.Play();
        Container.Clear();
        Container.Add(VolumeStuff);

    }

    void ExitGame()
    {
        SFX_Source.Play();
        Application.Quit();
        UnityEngine.Debug.Log("Quit.");
    }


}
