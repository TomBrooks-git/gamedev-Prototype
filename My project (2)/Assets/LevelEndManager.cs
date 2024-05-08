using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Singleton class "scoreboard"
public class LevelEndManager : MonoBehaviour
{
    public static LevelEndManager INSTANCE;
    private int totalKills = 0;
    private int damageTaken = 0;
    private string previousSceneName;

    private string missionStatus;
    private void Awake()
    {
        if(INSTANCE != null)
        {
            Destroy(gameObject);
            return;
        }

        INSTANCE = this;
        DontDestroyOnLoad(gameObject);
        previousSceneName = "SampleScene";
        missionStatus = "DEFAULT";
    }

    public void ZeroOutKills()
    {
        totalKills = 0;
    }
    public void IncrementKills()
    {
        totalKills++;
    }

    public int GetTotalKills()
    {
        return totalKills;
    }

    public void ZeroOutDamageTaken(){
        damageTaken = 0;
    }
    public void IncrementDamageTaken(int damage)
    {
        damageTaken+=damage;
    }

    public int GetDamageTaken(){
        return damageTaken;
    }

    public void SetPreviousSceneName(string sceneName){
        previousSceneName = sceneName;
    }

    public string GetPreviousSceneName(){
        return previousSceneName;
    }

    public string GetMissionStatus(){
        return missionStatus;
    }

    public void SetMissionStatus(string ms){
        missionStatus = ms;
    }

}
