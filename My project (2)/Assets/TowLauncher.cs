using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowLauncher : MonoBehaviour
{
    [SerializeField] public GameObject towPrefab;
    [SerializeField] float speed = 8f;
    bool canFire;
    [SerializeField] float timer = 7f;
    [SerializeField] float countUp = 0;

    void Start(){
        canFire = true;
    }

    void Update(){
        if(canFire == false){
            countUp += Time.deltaTime;
            if(countUp >= timer){
                canFire = true;
                countUp = 0;
            }
        }

    }

    
    public void Launch(){
        if(canFire){    
            GetComponent<AudioSource>().Play();
            GameObject newProjectile = Instantiate(towPrefab, transform.position, Quaternion.identity);
            Destroy(newProjectile, 10f);
            newProjectile.transform.rotation = towPrefab.transform.rotation = transform.rotation;
            newProjectile.GetComponent<Rigidbody2D>().velocity = newProjectile.transform.up * speed;
            canFire = false;
        }
    }
}
