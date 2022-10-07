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
    [SerializeField] public GameObject holder;

    [SerializeField] public int CoinToEvolve;
    [SerializeField] public GameObject LastDragon;
    [SerializeField] public GameObject NextDragon;
    [SerializeField] float characterSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float diveSpeed;

    // Bools for dragonabilities
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

    /// <summary>
    /// Moves Character by giving it velocity in given axis
    /// </summary>
    /// <param name="horizontalInput"></param>
    /// <param name="verticalInput"></param>
    public void DoMove(float horizontalInput, float verticalInput) 
    {
        float horizontalSpeed = horizontalInput * characterSpeed;
        float verticalSpeed = verticalInput * characterSpeed;

        Vector3 deltaMovement = new Vector3(horizontalSpeed, rigBody.velocity.y, verticalSpeed) * Time.deltaTime;
        Model.transform.Translate(deltaMovement);
    }

    /// <summary>
    /// Rotates the model by assigning it a new Quaternion
    /// </summary>
    /// <param name="newQuaternion"></param>
    public void DoRotate(Quaternion newQuaternion) {
        Model.transform.localRotation = newQuaternion;
    }

    // Function for making held objects move with the dragon
    public void DoMoveHolder(){
        var distanceToPlayer = Vector3.Distance(holder.transform.position, this.transform.position);


        //Make the holder move with the dragon
        if(distanceToPlayer > 2.0){
            holder.transform.position += (this.transform.position - holder.transform.position).normalized * characterSpeed * Time.deltaTime;
        }

        //Make crate jump with the dragon
        if (IsGrounded() == false){
            float Direction = Bottom.transform.position.y - holder.transform.position.y;
            Vector2 MovePos = new Vector2(
            holder.transform.position.x, 
            holder.transform.position.y + Direction);//MoveTowards on 1 axis
            holder.transform.position = MovePos;
        }
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

    // Makes Character fall slower - Glide
    public void DoGlide()
    {
        if (IsGrounded() == false && toggleGlide){
            rigBody.velocity = new Vector3(rigBody.velocity.x, -1, rigBody.velocity.z);
        }
    }

    // Checks if Character is in contact with a Ground tagged GameObject
    public bool IsGrounded()
    // TODO  - Not registering the grounded properly if the ground gameObject does not use the ground layer in the inspector (next to the tag).
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
