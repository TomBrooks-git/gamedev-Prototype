using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    public float windowWidth = 5f;
    public float windowHeight = 2f;

    private Vector3 windowCenter;

    // private float minXWorld = -31f;
    // private float maxXWorld = 13f;
    // private float minYWorld = -15f;
    // private float maxYWorld = 11f;

    void Start()
    {
        Vector3 screenSize = new Vector3(Screen.width, Screen.height, 0);
        windowCenter = Camera.main.ScreenToWorldPoint(screenSize / 2f);
    }

    void LateUpdate()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        float windowLeft = windowCenter.x - windowWidth / 2;
        float windowRight = windowCenter.x + windowWidth / 2;
        float windowTop = windowCenter.y + windowHeight / 2;
        float windowBottom = windowCenter.y - windowHeight / 2;

        // float cameraOrthographicSize = Camera.main.orthographicSize;
        // float cameraAspect = Camera.main.aspect;

        // float minX = minXWorld + cameraAspect * cameraOrthographicSize;
        // float maxX = maxXWorld - cameraAspect * cameraOrthographicSize;
        // float minY = minYWorld + cameraOrthographicSize;
        // float maxY = maxYWorld - cameraOrthographicSize;

        Vector3 cameraMovement = Vector3.zero;

        if (playerPosition.x < windowLeft)
        {
            cameraMovement += Vector3.left;
        }
        else if (playerPosition.x > windowRight)
        {
            cameraMovement += Vector3.right;
        }

        if (playerPosition.y < windowBottom)
        {
            cameraMovement += Vector3.down;
        }
        else if (playerPosition.y > windowTop)
        {
            cameraMovement += Vector3.up;
        }

        Vector3 newPosition = transform.position + cameraMovement * Time.deltaTime;

        // newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        // newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        transform.position = newPosition;
        windowCenter += cameraMovement * Time.deltaTime;
    }
}

