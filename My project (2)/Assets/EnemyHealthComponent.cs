using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthComponent : MonoBehaviour
{
    

    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private HUDTracker hudTracker;
    [SerializeField] private Sprite destroyedChassisSprite;
    [SerializeField] private Sprite destroyedTurretSprite;
    private SpriteRenderer sp;
    private SpriteRenderer turretSp;
    private GameObject turretObject;

    private float currentHealth;
    private T90TurretController turretController;

    private bool canBeDestroyed = true;
    
    [SerializeField] private ParticleSystem damageParticleSystem;
    void Start()
    {
        turretObject = transform.Find("T90Turret").gameObject;
        turretController = turretObject.GetComponent<T90TurretController>();
        sp = GetComponent<SpriteRenderer>();
        turretSp = turretObject.GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        
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
        
        if(canBeDestroyed){
            if (currentHealth <= 0)
            {
                DieSequence();
                canBeDestroyed = false;
            }
        }
    }

    private void DieSequence()
    {
        hudTracker.UpdateKills(1);
        damageParticleSystem.Stop();
        //here i want to dramatically increase the speed at which the damageParticleSystemObject is emitting particles. how?
        var emission = damageParticleSystem.emission;
        emission.rateOverTime = new ParticleSystem.MinMaxCurve(emission.rateOverTime.constantMax * 4);


        var main = damageParticleSystem.main;
        main.startSize = new ParticleSystem.MinMaxCurve(.3f);
        
        var renderer = damageParticleSystem.GetComponent<Renderer>();
        renderer.sortingOrder = 2;

        damageParticleSystem.Play();
        StartCoroutine(ResetEmissionRate());
        //replace the sprites
        sp.sprite = destroyedChassisSprite;
        turretSp.sprite = destroyedTurretSprite;
        
        Destroy(turretController); 
        Destroy(GetComponent<EnemyInput>());
    }

    private IEnumerator ResetEmissionRate()
    {
        yield return new WaitForSeconds(3);
        var emission = damageParticleSystem.emission;
        emission.rateOverTime = new ParticleSystem.MinMaxCurve(2f);
        damageParticleSystem.Play();
    }
}


