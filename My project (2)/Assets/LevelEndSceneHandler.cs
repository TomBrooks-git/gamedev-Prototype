using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEndSceneHandler : MonoBehaviour
{
    public void StartNextLevel(){
        if(LevelEndManager.INSTANCE.GetPreviousSceneName() == "SampleScene"){
            LevelEndManager.INSTANCE.ZeroOutDamageTaken();
            LevelEndManager.INSTANCE.ZeroOutKills();
            LevelEndManager.INSTANCE.SetPreviousSceneName("Level2");
            SceneManager.LoadScene("Level2");
        }
        else if(LevelEndManager.INSTANCE.GetPreviousSceneName() == "Level2"){
            LevelEndManager.INSTANCE.ZeroOutDamageTaken();
            LevelEndManager.INSTANCE.ZeroOutKills();
            LevelEndManager.INSTANCE.SetPreviousSceneName("Level3");
            SceneManager.LoadScene("Level3");
        }
        else if(LevelEndManager.INSTANCE.GetPreviousSceneName() == "Level3"){
            LevelEndManager.INSTANCE.ZeroOutDamageTaken();
            LevelEndManager.INSTANCE.ZeroOutKills();
            LevelEndManager.INSTANCE.SetPreviousSceneName("SamplesScene");
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void RetryLevel(){
        LevelEndManager.INSTANCE.ZeroOutDamageTaken();
        LevelEndManager.INSTANCE.ZeroOutKills();
        LevelEndManager.INSTANCE.SetPreviousSceneName(LevelEndManager.INSTANCE.GetPreviousSceneName());
        SceneManager.LoadScene(LevelEndManager.INSTANCE.GetPreviousSceneName());
    }

    public void Quit(){
        LevelEndManager.INSTANCE.ZeroOutDamageTaken();
        LevelEndManager.INSTANCE.ZeroOutKills();
        LevelEndManager.INSTANCE.SetPreviousSceneName("SampleScene");
        SceneManager.LoadScene("MainMenu");
    }

    
}
