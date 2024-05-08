using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyInput : MonoBehaviour
{
    public float rotationInterval = 7f; // Interval for random rotation
    public float rotationSpeed = .05f; 
    private Transform playerTransform; 
    private Transform chassisTransform; 
    private Quaternion targetRotation; 
    private float rotationTimer = 0f; 
    private bool PlayerEngaged;
    public float angleThreshold = 30f;
    private GameObject player;
    void Start()
    {
        PlayerEngaged = false;
        chassisTransform = transform; 
        SetTargetRotation();
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player GameObject not found in the scene!");
        }
    }

    void Update()
    {
        SetTargetRotation();
        RotateChassis();
    }

    void SetTargetRotation()
    {
        if(!PlayerEngaged){ //random rotation routine
            Debug.Log("Player engaged is false");
            rotationTimer += Time.deltaTime;
            if (rotationTimer >= rotationInterval)
            {
                Debug.Log("Entering into unengaged loiter mode");
                rotationTimer = 0;
                float randomAngle = Random.Range(0f, 360f);
                targetRotation = Quaternion.Euler(0f, 0f, randomAngle);
            }
        }
        else{
            Debug.Log("Playe engaged is true");
            if(playerTransform == null){
                Debug.Log("playerTransform is null for some reason");
            }
            Vector3 ChangeDirection = (playerTransform.position - chassisTransform.position).normalized;
                    
            Vector3 direction = playerTransform.position - chassisTransform.position;
            Vector3 forwardDirection = chassisTransform.forward;
            float dotProduct = Vector3.Dot(forwardDirection, direction.normalized);
            dotProduct = Mathf.Clamp(dotProduct, -1f, 1f);
            float angleDifference = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

            Debug.Log("angle differece: " + angleDifference + " angle threshold: " + angleThreshold);
            if (angleDifference > angleThreshold)
            {
                targetRotation = Quaternion.LookRotation(Vector3.forward, ChangeDirection);
            }
            else
            {
                targetRotation = chassisTransform.rotation;
            }
            //Vector3 direction = (playerTransform.position - chassisTransform.position).normalized;
            //targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
    }


    void RotateChassis()
    {
        float angularVelocity = 8 * Time.deltaTime;
        chassisTransform.rotation = Quaternion.RotateTowards(chassisTransform.rotation, targetRotation, angularVelocity);
    }

    public void SetPlayerEngaged(bool status){
        this.PlayerEngaged = status;
    }

}
