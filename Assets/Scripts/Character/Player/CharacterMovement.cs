using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float
          characterSpeed = 5f,
          jumpSpeed = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * characterSpeed, 
                                  rb.velocity.y, 
                                  verticalInput * characterSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded()) {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z); 
        }
    }

    bool isGrounded() {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
