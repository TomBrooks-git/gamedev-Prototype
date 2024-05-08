using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    private bool isPaused = false;
        public void Update(){
            if (Input.GetKeyDown(KeyCode.Escape)){
                if(!isPaused){
                    pausePanel.SetActive(true);
                    Time.timeScale = 0f;
                    isPaused = true;
                }
                else{
                    pausePanel.SetActive(false);
                    Time.timeScale = 1.0f;
                    isPaused = false;
                }
                Debug.Log("Escape key was pressed");
                
            }
        }
        public void Resume(){
            pausePanel.SetActive(false);
            Time.timeScale = 1.0f;
            isPaused = false;
        }

        public void Home(){
            LevelEndManager.INSTANCE.ZeroOutDamageTaken();
            LevelEndManager.INSTANCE.ZeroOutKills();
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("MainMenu");
        }
}
