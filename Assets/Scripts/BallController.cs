using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    public GameObject hand;
    public Transform cameraTransform;
    Rigidbody handRb;
    public float movementSpeed = 5f;
    bool contraintsRemoved = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        handRb = hand.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;  // Disable physics initially
            handRb.constraints = RigidbodyConstraints.FreezePositionY;  // Disable physics initially
        }
        else
        {
            Debug.LogError("Ball Rigidbody not found!");
        }
    }

    private void FixedUpdate()
    {
        if (!contraintsRemoved)
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            rb.velocity = movement * movementSpeed;
            handRb.velocity = rb.velocity;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !contraintsRemoved)
        {
            hand.SetActive(false);
            rb.constraints = RigidbodyConstraints.None;
            contraintsRemoved = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zone1"))
        {
            Debug.Log("Zone 1 Entered");
        }
        else if (other.CompareTag("Zone2"))
        {
            Debug.Log("Zone 2 Entered");
        }
        else if (other.CompareTag("Zone3"))
        {
            Debug.Log("Zone 3 Entered");
        }
        else if (other.CompareTag("Zone4"))
        {
            Debug.Log("Zone 4 Entered");
        }
    }

    private void LateUpdate()
    {
        cameraTransform.rotation = Quaternion.Euler(0, 0, 0);
    }

}
