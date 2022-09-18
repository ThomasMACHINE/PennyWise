using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// HOW TO USE
/*
 * Attach this script to the GameObject that holds the Model for the Dragon
 * Set all values for the new DragonType
 * Save the GameObject as a Prefab in the Prefab folder
*/

/// <summary>
/// The Dragon class holds all the base stats for movement and cost to unlock - Objects of this class should not be instantiated by code but
/// rather through Unity and saved as prefabs
/// </summary>
public class Dragon : MonoBehaviour
{
    [SerializeField] GameObject Model;
    [SerializeField] GameObject Bottom;
    private Rigidbody rigBody;
    private Collider modelCollider;
    [SerializeField] LayerMask groundLayer;

    [SerializeField] public int CoinToEvolve;
    [SerializeField] public GameObject LastDragon;
    [SerializeField] public GameObject NextDragon;
    [SerializeField] float characterSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float diveSpeed;

    [SerializeField] bool canDoubleJump;

    public bool IsCaught;
    public int UnAccountedCoins; // This is very sad, but checking for collision is much easier within the object

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        modelCollider = GetComponent<Collider>();
        rigBody = GetComponent<Rigidbody>();
    }

    public void DoMove(float horizontalInput, float verticalInput) 
    {
        float horizontalSpeed = horizontalInput * characterSpeed;
        float verticalSpeed = verticalInput * characterSpeed;

        rigBody.velocity = new Vector3(horizontalSpeed, rigBody.velocity.y, verticalSpeed);
    }

    public void DoJump()
    {
       
        if(IsGrounded()) {
            rigBody.velocity = new Vector3(rigBody.velocity.x, jumpSpeed, rigBody.velocity.z);
        }
        else
        {
            //Remember to remove when double jump has been implemented.
            Debug.Log("Not on the ground layer! Can not jump!");
        }
    }
    //Not registering the grounded properly if the ground gameObject does not use the ground layer in the inspector (next to the tag).
    //Player also needs to have ground as the groundLayer.
    public bool IsGrounded()
    {
        return Physics.CheckSphere(Bottom.transform.position, 0.1f, groundLayer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Guard"))
            IsCaught = true;

        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            UnAccountedCoins += 1;
        }
    }
}
