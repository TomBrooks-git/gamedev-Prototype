using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthComponent : MonoBehaviour
{
    

    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private HUDTracker hudTracker;
    private float currentHealth;
    
    [SerializeField] private ParticleSystem damageParticleSystem;
    void Start()
    {
        currentHealth = maxHealth;
        //damageParticleSystem = GetComponent<ParticleSystem>();
        damageParticleSystem.Stop();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        
        if(currentHealth < 100)
        {
            damageParticleSystem.Play();
        }

        if (currentHealth <= 0)
        {
            DieSequence();
        }
       
    }

    private void DieSequence()
    {
        hudTracker.UpdateKills(1);
        Destroy(gameObject); 
    }
}


