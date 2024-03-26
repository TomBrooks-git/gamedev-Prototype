using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySabot : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            //ApplyDamage(other.gameObject);
            Debug.Log("PlayerHit");
            HealthComponent playerHealth = other.gameObject.GetComponent<HealthComponent>();
            playerHealth.TakeDamage(20);
            Destroy(this.gameObject);
        }
        else if(other.gameObject.tag == "Building"){
            Debug.Log("EnemySabot hit building");
            Destroy(this.gameObject);
        }
    }
}
