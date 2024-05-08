using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDTracker : MonoBehaviour
{
    private int T90Count;
    private float hullIntegrity;
    [SerializeField] private TextMeshProUGUI killsText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private BradleyChassis player;
    private TurretController turret; 
    [SerializeField] UnityEngine.UI.Image sabotSelectedTile;
    [SerializeField] UnityEngine.UI.Image towSelectedFile;
    void Start()
    {
        Debug.Log("Instantiation of a HUD Tracker");
        turret = player.GetComponentInChildren<TurretController>();
        T90Chassis[] totalT90 = GameObject.FindObjectsOfType<T90Chassis>();
        T90Count = totalT90.Length;
        hullIntegrity = 100f;
    }

   
    void Update()
    {
        Color color = Color.white;
        Color sabotTile = Color.white;
        Color towTile = Color.white;
        switch (turret.GetSelectedWeapon()) {
            
            case 1: 
                sabotTile.a = 1f;
                towTile.a = 0.608f; 
                break;
            case 2: 
                sabotTile.a = 0.608f;
                towTile.a = 1f;  
                break;
            default: 
                sabotTile.a = 0.608f;
                towTile.a = 0.608f; 
                break;
        }
        sabotSelectedTile.color = sabotTile;
        towSelectedFile.color = towTile;
        
        killsText.text = "Enemies\nRemaining: " + T90Count.ToString();
        healthText.text = "Hull\nIntegrity: " + hullIntegrity.ToString();
        if(T90Count == 0){
            StartCoroutine(proceedToLevelManager());
        }
    }

    private IEnumerator proceedToLevelManager(){
        LevelEndManager.INSTANCE.SetMissionStatus("Occupiers Destroyed - Mission Success");
        Debug.Log("Player has completed level, proceeding to Level Summary Manager");
        yield return new WaitForSeconds(3);
        LevelEndManager.INSTANCE.SetPreviousSceneName(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("LevelEndScene");

    }

    public void UpdateKills(int kill){
        T90Count-=kill;
        LevelEndManager.INSTANCE.IncrementKills();
    }
    public void UpdateHealth(float damage){
        hullIntegrity+=damage;
        
    }
}
