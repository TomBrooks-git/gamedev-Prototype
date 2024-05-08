using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{


    [SerializeField] BradleyChassis chassis;

    void Start(){
        if (chassis == null)
        {
            chassis = FindObjectOfType<BradleyChassis>();
            if (!chassis)
            {
                Debug.LogError("BradleyChassis reference not assigned");
            }
        }
    }
    
    void Update(){

        Bradley();
    }



    void Bradley(){
            Vector3 chassisRotate = Vector3.zero;
            Vector3 chassisMovement = Vector3.zero;
            

            if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)){
                chassisRotate.z -= 1;
                if(!Input.GetKey(KeyCode.Space)){
                    chassisMovement.y += 0.1f;
                }
                chassis.RotateBradleyChassis(chassisRotate);
                chassis.MoveBradleyChassis(chassisMovement);
                return;
            }
            if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)){
                chassisRotate.z += 1;
                if(!Input.GetKey(KeyCode.Space)){
                    chassisMovement.y += 0.1f;
                }
                chassis.RotateBradleyChassis(chassisRotate);
                chassis.MoveBradleyChassis(chassisMovement);
                return;
            }
            if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)){
                chassisRotate.z -= 1;
                if(!Input.GetKey(KeyCode.Space)){
                    chassisMovement.y -= 0.1f;
                }
                chassis.RotateBradleyChassis(chassisRotate);
                chassis.MoveBradleyChassis(chassisMovement);
                return;
            }
            if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)){
                chassisRotate.z += 1;
                if(!Input.GetKey(KeyCode.Space)){
                    chassisMovement.y -= 0.1f;
                }
                chassis.RotateBradleyChassis(chassisRotate);
                chassis.MoveBradleyChassis(chassisMovement);
                return;
            }

            if(Input.GetKey(KeyCode.W)){
                Debug.Log("W is pressed");
                chassisMovement.y += 1;
            }
            if(Input.GetKey(KeyCode.S)){

                chassisMovement.y -= 1;
            }
            if(Input.GetKey(KeyCode.A)){
                Debug.Log("A is pressed");
                chassisMovement.z += 1;
            }
            if(Input.GetKey(KeyCode.D)){
                Debug.Log("D is pressed");
                chassisMovement.z += -1;
            }
            
            chassis.MoveBradleyChassis(chassisMovement);

           
    }


}
