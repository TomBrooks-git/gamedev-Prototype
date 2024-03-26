using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private HUDTracker hudTracker;

    [SerializeField] private float maxHealth = 100f;
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
            StartCoroutine(DieSequence());
        }
        hudTracker.UpdateHealth(damage * -1);
    }

    private IEnumerator DieSequence()
    {
        Debug.Log("Player Has Died, Returnin to Main Menu");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu"); 
    }
}

