using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    
    [SerializeField] float rotationSpeed = 0.5f;
    [SerializeField] public float speed = 50.0f;
    private Rigidbody2D rb;


    void Start(){
        rb = GetComponent<Rigidbody2D>();
        if(rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on " + gameObject.name);
        }
        else
        {
            Debug.Log("Successfully referenced Rigidbody2D");
        }
    }

    public void MoveT90Chassis(Vector3 direction)
    {
        Debug.Log("MoveT90Chassis Invoked");

        if(rb == null)
        {
            Debug.LogWarning("Rigidbody2D component is null, attempting to retrieve again");
            rb = GetComponent<Rigidbody2D>();
            if(rb == null)
            {
                Debug.LogError("Failed to retrieve Rigidbody2D component");
                return; 
            }
        }

        Vector3 actualDirection = transform.TransformDirection(direction); 
        rb.AddForce(actualDirection * speed * Time.deltaTime);

    }

    public void RotateT90Chassis(Vector3 rotation){
        //rotation.z *= rotationSpeed;
        transform.Rotate(rotation);  
    }
}
