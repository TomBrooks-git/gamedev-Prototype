using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private HUDTracker hudTracker;
    [SerializeField] private Sprite destroyedChassisSprite;
    [SerializeField] private Sprite destroyedTurretSprite;
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    [SerializeField] private ParticleSystem damageParticleSystem;
    private GameObject turretObject;
    private SpriteRenderer sp;
    private SpriteRenderer turretSp;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        turretObject = transform.Find("BradleyTurret").gameObject;
        turretSp = turretObject.GetComponent<SpriteRenderer>();
        
        currentHealth = maxHealth;
        //damageParticleSystem = GetComponent<ParticleSystem>();
        damageParticleSystem.Stop();
    }


    public void TakeDamage(float damage)
    {
        LevelEndManager.INSTANCE.IncrementDamageTaken((int)damage);
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
        sp.sprite = destroyedChassisSprite;
        turretSp.sprite = destroyedTurretSprite;
        Debug.Log("Player Has Died, Proceeding to Level End Manager");
        yield return new WaitForSeconds(3);
        LevelEndManager.INSTANCE.SetMissionStatus("Mission Failed");
        LevelEndManager.INSTANCE.SetPreviousSceneName(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("LevelEndScene"); 
    }

    public void Heal(float healBy){
        if(currentHealth >= 100){
            Debug.Log("Aborting Heal Function: Current Health is: " + currentHealth);
            return;
        }
        currentHealth+=healBy;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        if(currentHealth >=100){
            damageParticleSystem.Stop();
        }
        hudTracker.UpdateHealth(healBy);
    }
}

