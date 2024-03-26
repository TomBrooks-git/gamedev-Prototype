using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sabot : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "EnemyVehicle"){
            
            Debug.Log("T90 Hit");
            EnemyHealthComponent enemyHealth = other.gameObject.GetComponent<EnemyHealthComponent>();
            enemyHealth.TakeDamage(7);
            Destroy(this.gameObject);
        }
        else if(other.gameObject.tag == "Building"){
            Debug.Log("Sabot hit building");
            Destroy(this.gameObject);
        }
    }

}
