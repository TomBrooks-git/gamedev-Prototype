using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDTracker : MonoBehaviour
{
    private int T90Count;
    private float hullIntegrity;
    [SerializeField] private TextMeshProUGUI killsText;
    [SerializeField] private TextMeshProUGUI healthText;
    void Start()
    {
        T90Chassis[] totalT90 = GameObject.FindObjectsOfType<T90Chassis>();
        T90Count = totalT90.Length;
        hullIntegrity = 100f;
    }

   
    void Update()
    {
        killsText.text = "Enemies\nRemaining: " + T90Count.ToString();
        healthText.text = "Hull\nIntegrity: " + hullIntegrity.ToString();
        if(T90Count == 0){
            StartCoroutine(returnToMainForDemo());
        }
    }

    private IEnumerator returnToMainForDemo(){
        Debug.Log("Player has completed Demo Layer, Returning to main");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu");

    }

    public void UpdateKills(int kill){
        T90Count-=kill;
    }
    public void UpdateHealth(float damage){
        hullIntegrity+=damage;
    }
}
