using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField] BradleyChassis player;
    public float windowWidth = 5f;
    public float windowHeight = 2f;

    private Vector3 windowCenter;

    void Start()
    {
        Vector3 screenSize = new Vector3(Screen.width, Screen.height, 0);
        windowCenter = Camera.main.ScreenToWorldPoint(screenSize / 2f);
    }

    void LateUpdate()
    {
        Vector3 playerPosition = player.transform.position;

        float windowLeft = windowCenter.x - windowWidth / 2;
        float windowRight = windowCenter.x + windowWidth / 2;
        float windowTop = windowCenter.y + windowHeight / 2;
        float windowBottom = windowCenter.y - windowHeight / 2;

        // Check if player is within inner frame
        if (playerPosition.x < windowLeft)
        {
            windowCenter.x -= (windowLeft - playerPosition.x);
        }
        else if (playerPosition.x > windowRight)
        {
            windowCenter.x += (playerPosition.x - windowRight);
        }

        if (playerPosition.y < windowBottom)
        {
            windowCenter.y -= (windowBottom - playerPosition.y);
        }
        else if (playerPosition.y > windowTop)
        {
            windowCenter.y += (playerPosition.y - windowTop);
        }

        transform.position = new Vector3(windowCenter.x, windowCenter.y, transform.position.z);
    }
}
