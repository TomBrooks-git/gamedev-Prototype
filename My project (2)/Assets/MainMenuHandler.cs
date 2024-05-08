using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel;
    public void Play(){
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit(){
        Application.Quit();
    }

    public void OpenSettingsMenu(){
        settingsPanel.SetActive(true);
    }

    public void CloseSettingsManu(){
        settingsPanel.SetActive(false);
    }

    
}

