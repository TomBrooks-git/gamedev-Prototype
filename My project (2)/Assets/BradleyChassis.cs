using UnityEngine;

public class BradleyChassis : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 0.1f;
    [SerializeField] public float speed = 75.0f;
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

    public void MoveBradleyChassis(Vector3 direction)
    {
        Debug.Log("MoveBradleyChassis Invoked");

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

    public void RotateBradleyChassis(Vector3 rotation){
        rotation.z *= rotationSpeed;
        transform.Rotate(rotation);  
    }
}
