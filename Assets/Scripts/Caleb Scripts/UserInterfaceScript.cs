using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UserInterfaceScript : MonoBehaviour
{

    private void onEnable()
    {
        VisualElement root = GetComponent<UIDocument>.rootVisualElement;

        Button playButton = root.Q<Button>("PlayButton");
        Button settingsButton = root.Q<Button>("SettingsButton");
        Button quitButton = root.Q<Button>("QuitButton");
        

    }



}
