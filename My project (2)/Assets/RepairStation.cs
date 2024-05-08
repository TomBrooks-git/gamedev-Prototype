using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairStation : MonoBehaviour
{

    [SerializeField] BradleyChassis player;
    private bool inHealRadius;
    private HealthComponent hc;
    void Start(){
        inHealRadius = false;
        hc = player.GetComponent<HealthComponent>();
        if(!hc){
            Debug.Log("Health Component is null for some reason");
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            inHealRadius = true;
            StartCoroutine(healPlayer());
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            inHealRadius = false;
            StopCoroutine(healPlayer());
        }
    }

    private IEnumerator healPlayer(){
        yield return new WaitForSeconds(3);
        while(inHealRadius){    
            hc.Heal(5);
            yield return new WaitForSeconds(3);
        }
    }
}
