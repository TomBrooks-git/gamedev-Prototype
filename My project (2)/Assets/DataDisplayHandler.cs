using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataDisplayHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI missionStatus;
    [SerializeField] private TextMeshProUGUI occupiersDestroyed;
    [SerializeField] private TextMeshProUGUI damageSustained;

    public void Update(){
        missionStatus.text = LevelEndManager.INSTANCE.GetMissionStatus();
        occupiersDestroyed.text = LevelEndManager.INSTANCE.GetTotalKills().ToString();
        damageSustained.text = LevelEndManager.INSTANCE.GetDamageTaken().ToString();
    }
}
