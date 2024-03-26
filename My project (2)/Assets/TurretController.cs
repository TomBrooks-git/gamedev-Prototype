using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Transform turretTransform;
    ProjectileLauncher pl;

    void Start(){
        turretTransform = this.transform;
        pl = this.GetComponentInChildren<ProjectileLauncher>();
    }
    void Update()
    {    
        Vector3 targetPos = Input.mousePosition;
        targetPos = Camera.main.ScreenToWorldPoint(new Vector3(targetPos.x, targetPos.y, Camera.main.transform.position.z));
        Vector3 direction = targetPos - turretTransform.position;
        turretTransform.rotation = Quaternion.LookRotation(transform.forward, targetPos - transform.position);
        if(Input.GetMouseButtonDown(0)){
            pl.Launch();      
        }
    }
}

