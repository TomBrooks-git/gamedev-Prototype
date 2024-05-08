
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Transform turretTransform;
    ProjectileLauncher pl;
    TowLauncher tl;

    private int selectedWeapon = 1;

    void Start(){
        turretTransform = this.transform;
        pl = GetComponentInChildren<ProjectileLauncher>();
        tl = GetComponentInChildren<TowLauncher>();
    }
    void Update()
    {    
        Vector3 targetPos = Input.mousePosition;
        targetPos = Camera.main.ScreenToWorldPoint(new Vector3(targetPos.x, targetPos.y, Camera.main.transform.position.z));
        Vector3 direction = targetPos - turretTransform.position;
        turretTransform.rotation = Quaternion.LookRotation(transform.forward, targetPos - transform.position);
        
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            selectedWeapon = 1;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)){
            selectedWeapon = 2;
        }
        
        //Input.GetMouseButton(0)
        //Input.GetMouseButtonDown(0)
        // if(Input.GetMouseButtonDown(0)){
        //     if(selectedWeapon== 1){    
        //         pl.Launch();      
        //     }
        //     else if(selectedWeapon == 2){
        //         tl.Launch();
        //     }
        // }


        if(selectedWeapon == 1){
            if(Input.GetMouseButton(0)){
                pl.Launch();
            }
        }
        else if(selectedWeapon == 2){
            if(Input.GetMouseButtonDown(0)){
                tl.Launch();
            }
        }
    }

    public int GetSelectedWeapon(){
        return selectedWeapon;
    }
}

