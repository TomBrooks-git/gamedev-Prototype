using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T90Chassis : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 0.1f;
    [SerializeField] float speed = 100.0f;
    private Rigidbody2D rb;
    void Start(){
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void MoveT90Chassis(Vector3 direction){
        Vector3 actualDirection = transform.TransformDirection(direction); 
        rb.AddForce(actualDirection * speed * Time.deltaTime);
    }

    public void RotateT90Chassis(Vector3 rotation){
        rotation.z *= rotationSpeed;
        transform.Rotate(rotation);  
    }
}
