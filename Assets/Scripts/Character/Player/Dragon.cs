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
    [SerializeField] Interactable interactable; //Remove Later

    [SerializeField] public int CoinToEvolve;
    [SerializeField] public GameObject LastDragon;
    [SerializeField] public GameObject NextDragon;
    //Does not affect the actual speed of the object on a horizontal level (unsure about vertical). That is handled in playerController.
    [SerializeField] float characterSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float diveSpeed;

    //Can remove if not needed
    [SerializeField] bool canGlide;
    
    [SerializeField] bool canDoubleJump;

    [SerializeField] private int jumpCount;
    private bool toggleGlide;
    public bool toggleHold;

    public bool IsCaught;
    public int UnAccountedCoins; // This is very sad, but checking for collision is much easier within the object


    private void Awake() {
    
       // DontDestroyOnLoad(this.gameObject);
        //DontDestroyOnLoad(NextDragon);
        modelCollider = GetComponent<Collider>();
        rigBody = GetComponent<Rigidbody>();
        toggleHold = false;
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
            jumpCount = 1;
            toggleGlide = false;
            rigBody.velocity = new Vector3(rigBody.velocity.x, jumpSpeed, rigBody.velocity.z);
            
            
        }
        else {
            // Dragon can glide if it is small size, here it checks to toggle or untoggle it
            if (this.gameObject.name.Contains("SMALL") && Input.GetKeyDown(KeyCode.Space)) {
                Debug.Log("I am gliding!");
                if (toggleGlide) {
                    toggleGlide = false;
                } else {
                    toggleGlide = true;
                }
            }
            // If the dragon can double jump AND the jump count is below 2
            if (canDoubleJump && jumpCount < 2) {
                jumpCount += 1;
                rigBody.velocity = new Vector3(rigBody.velocity.x, jumpSpeed, rigBody.velocity.z);
            }
            else if (jumpCount != 1) {
                Debug.Log("Can't jump more in the air");
            }
            else {
                Debug.Log("Not on the ground layer! Can not jump!");
            }
            
        }
    }

    // Function for updating the decent of a gliding dragon
    public void DoGlide()
    {
        if (IsGrounded() == false && toggleGlide){
            rigBody.velocity = new Vector3(rigBody.velocity.x, -1, rigBody.velocity.z);
        }
    }


    //Not registering the grounded properly if the ground gameObject does not use the ground layer in the inspector (next to the tag).
    //Player also needs to have ground as the groundLayer.
    public bool IsGrounded()
     {
        bool isGrounded = Physics.CheckSphere(Bottom.transform.position, 0.3f, groundLayer);
        if (isGrounded) { jumpCount = 1; }
        return Physics.CheckSphere(Bottom.transform.position, 0.3f, groundLayer);
    }

    //Should move this into the coin, and from there update the global coinscore.
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Coin coin = collision.gameObject.GetComponent<Coin>();
            if (coin.CanBePicked) {
                Destroy(collision.gameObject);
                UnAccountedCoins += 1;
            }
            
        }
    }*/

    // ... Look at the comment above.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Guard"))
            IsCaught = true;

        if (other.gameObject.CompareTag("Coin"))
        {
            //Updates the global variable
            CoinScore.globalCoinScore += 1;
            Debug.Log(CoinScore.globalCoinScore + " The global score being updated after picking up a coin");
            Destroy(other.gameObject);
            UnAccountedCoins += 1;
        
        }
    
    }

   

}
