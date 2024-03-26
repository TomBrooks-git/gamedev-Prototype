using UnityEngine;

public class T90TurretController : MonoBehaviour
{
    public Transform turretTransform;
    public float rotationSpeed = 5f;

    private Transform playerTransform; // Reference to the player's transform
    private bool playerInRadius = false;

    ProjectileLauncher pl;

    void Start()
    {
        turretTransform = transform; // Assuming the turret is the root object
        pl = this.GetComponentInChildren<ProjectileLauncher>();
        // Find the player object by tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
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
        if (playerInRadius)
        {
            LookAtPlayer();
            pl.Launch();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRadius = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRadius = false;
        }
    }

    void LookAtPlayer()
    {
        // Calculate the direction towards the player
        Vector3 direction = (playerTransform.position - turretTransform.position).normalized;

        // Calculate the rotation angle towards the player
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);

        // Smoothly rotate the turret towards the player
        turretTransform.rotation = Quaternion.RotateTowards(turretTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
