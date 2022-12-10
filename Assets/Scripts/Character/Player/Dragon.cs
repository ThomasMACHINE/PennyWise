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
    //Model, rigidbodies and bottom:
    [SerializeField] GameObject Model;
    [SerializeField] GameObject Bottom;
    public Rigidbody rigBody { private set; get; }
    private Collider modelCollider;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] public GameObject holder;

    //How many coins are needed to reach the next size
    [SerializeField] public int CoinToEvolve;

    //Previous and next models
    [SerializeField] public GameObject LastDragon;
    [SerializeField] public GameObject NextDragon;

    //Character variables for movement
    [SerializeField] float characterSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float diveSpeed;

    //UI elements
    [SerializeField] EvolveBar evolveBar; 
    [SerializeField] Abilities icons;

    //NPCs
    [SerializeField] Guard guard;
    private Color guardRedColor = new Color(0.840f, 0.000f, 0.043f);
    private Color guardWhiteColor = new Color(255,255,255);
    // Threshold for Guard finding dragon
    private float VelocityHidingThreshold = 0.5f;
    

    //Vision
    [SerializeField] GameObject stepRayLower;
    [SerializeField] GameObject stepRayHigher;
    [SerializeField] LayerMask obstructionMask;

    //Animator
    [SerializeField] DragonAnimator characterAnimator;

    // How smooth is the tranition when stepping up.
    [SerializeField] float stepSmooth = 0.5f;
    //Creates a list of gameObjects in scene.
    [SerializeField] private GameObject[] guardObjectsInScene;

    //Sounds
    public AudioSource coinPickUpSound;
    public AudioSource roarSound;
    public AudioSource singleJumpSound;
    public AudioSource doubleJumpSound;
    public AudioSource landSound;
    public AudioSource step1;
    public AudioSource step2;
    public AudioSource step3;
    public AudioSource step4;
    public AudioSource step5;
    public AudioSource step6;
    public AudioSource step7;
    public AudioSource step8; 
    
    //Variables to keep track of abilities used or sounds used
    private bool roarUsedRecently;
    public bool jumpedRecently;
    private int stepID;
    public bool toggleGlide;
    public bool toggleHold;
    public bool IsCaught;
   

    // Bools for dragonabilities
    [SerializeField] bool canGlide;
    [SerializeField] bool canDoubleJump;
    [SerializeField] private int jumpCount;
    [SerializeField] bool canRoar;

    //Variables related to the Bush object
    private GameObject insideBush;
    public bool hidden;
    private bool isCarryingBush;
    private Bush heldBush;

    //Possible dragonsizes
    public enum DragonSize
    {
        none, SMALL, MEDIUM, LARGE
    }
    [SerializeField] public DragonSize size;

    private void Awake() {
        guardObjectsInScene = GameObject.FindGameObjectsWithTag("Guard");
        modelCollider = GetComponent<Collider>();
        rigBody = GetComponent<Rigidbody>();
        toggleHold = false;
        hidden = false;
        jumpedRecently = false;
        stepID = 0;
    }

    void Start() {
        evolveBar.UpdateScore(CoinScore.globalTotalCoinScore);
    }

    /// <summary>
    /// Resets guards after shrinking
    /// </summary>
    public void ResetGuardsAfterDeevolving() {
         // if a player deevolves, it should terminate the guard scared state.
        if (guardObjectsInScene.Length > 0) {
            foreach (GameObject guard in guardObjectsInScene) {
                //Renderer renderer = guard.GetComponent<Renderer>();
                if (guard.GetComponent<Renderer>().material.color != guardRedColor) {
                    guard.GetComponent<Renderer>().material.color = guardRedColor;
                }
                if (!guard.GetComponent<CapsuleCollider>().enabled) {
                    guard.GetComponent<CapsuleCollider>().enabled = true;
                }
            }
        }
        roarUsedRecently = false;
    }

    /// <summary>
    /// Moves Character by giving it velocity in given axis
    /// </summary>
    /// <param name="xInput"></param>
    /// <param name="zInput"></param>
    public void DoMove(float xInput, float zInput) 
    {
        float xSpeed = xInput * characterSpeed;
        float zSpeed = zInput * characterSpeed;
        
        if(xSpeed == 0 && zSpeed == 0)
        {
            characterAnimator.StopWalkAnimation();
            return;
        }

        characterAnimator.ActivateWalkAnimation();
        Vector3 movement = new Vector3(xSpeed, rigBody.velocity.y, zSpeed);
        rigBody.velocity = rigBody.rotation * movement;
        //Sounds for walking
        if(IsGrounded()) { playSoundSteps(); }
    }

    /// <summary>
    /// Plays the sound of the next footstep
    /// </summary>
    public void playSoundSteps(){
        
        if (!step1.isPlaying && !step2.isPlaying && !step3.isPlaying && !step4.isPlaying &&!step5.isPlaying && !step6.isPlaying && !step6.isPlaying && !step8.isPlaying){
            switch(stepID) 
            {
                case 1:
                step1.Play();
                break;

                case 2:
                step2.Play();
                break;

                case 3:
                step3.Play();
                break;

                case 4:
                step4.Play();
                break;

                case 5:
                step5.Play();
                break;

                case 6:
                step6.Play();
                break;

                case 7:
                step7.Play();
                break;

                case 8:
                step8.Play();
                break;

                default:
                break;
            }
        //Update stepID
            if (stepID >= 8){
                stepID = 1;
            } else {
                stepID += 1;
            }
        }

        
    }

    /// <summary>
    /// Rotates the model by assigning it a new Quaternion
    /// </summary>
    /// <param name="newQuaternion"></param>
    public void DoRotate(Quaternion newQuaternion) {
        rigBody.MoveRotation(newQuaternion);
        
    }
    /// <summary>
    /// Function for making the dragon drop held items
    /// </summary>
    public void DropHeldItem () {
        if(holder){
            
            while (holder.transform.childCount > 0) {
                foreach (Transform child in holder.transform) {
                    //Turning on gravity
                    Rigidbody objRig = child.GetComponent<Rigidbody>();
                    objRig.useGravity = true;
                    //Removing parent
                    child.gameObject.transform.parent = null;
                }
            }
        }
        //Dropping bush
        if(insideBush){
            if (insideBush.transform.parent != null){
                insideBush.transform.parent = null;
            }
        }
        if (heldBush){
            heldBush.Drop();
            isCarryingBush = false;
            heldBush.gameObject.transform.parent = null;
        }      
    }

    /// <summary>
    /// Makes it possible to pick up the bush
    /// </summary>
    public void UpdateBush(){
        // If Dragon is holding a bush and Player wants to drop the bush
        if (heldBush && Input.GetKeyDown(KeyCode.V))
        {
            heldBush.Drop();
            isCarryingBush = false;
            heldBush.gameObject.transform.parent = null;
            return;
        }
        //Picking up bush
        if (insideBush && Input.GetKeyDown(KeyCode.C)){
            if (isCarryingBush)
                return;

            heldBush = insideBush.GetComponent<Bush>();
            heldBush.enabled = true;
            heldBush.PickUp();
            isCarryingBush = true;
            insideBush.transform.parent = this.transform;
        }
    }

    /// <summary>
    /// Controls the jump of the dragon
    /// </summary>
    public void DoJump()
    {
        
        if(IsGrounded()) {
            //Sound
            singleJumpSound.Play();
            jumpCount = 1;
            toggleGlide = false;
            rigBody.velocity = new Vector3(rigBody.velocity.x, jumpSpeed, rigBody.velocity.z); 
            }
        else {
            // Dragon can glide if it is small size, here it checks to toggle or untoggle it
            if (size == DragonSize.SMALL && Input.GetKeyDown(KeyCode.Space)) {
                if (toggleGlide) {
                    toggleGlide = false;
                } else {
                    toggleGlide = true;
                }
            }
            // If the dragon can double jump AND the jump count is below 2
            if (canDoubleJump && jumpCount < 2) {
                //Sound
                doubleJumpSound.Play();
                jumpCount += 1;
                rigBody.velocity = new Vector3(rigBody.velocity.x, jumpSpeed, rigBody.velocity.z);
            }
            else if (jumpCount != 1) {
            }
            else {
            }
            
        }
    }

    /// <summary>
    /// Function controlling the glide mechanic
    /// </summary>
    public void DoGlide()
    {
        if (IsGrounded() == false && toggleGlide){
            characterAnimator.ActivateGlideAnimation();
            rigBody.velocity = transform.forward * characterSpeed;
            rigBody.velocity = new Vector3(rigBody.velocity.x, -1, rigBody.velocity.z);
            
        }
        else
        {
            toggleGlide = false;
            characterAnimator.StopGlideAnimation();
        }
    }

    /// <summary>
    /// Function handles entering bush
    /// </summary>
    public void InteractBushEnter(GameObject seenBush, DragonSize size){
        // Return if player is already inside another bush
        if (insideBush)
        {
            return;
        }

        switch (size)
        {
            case DragonSize.SMALL:
                hidden = true;
                break;

            case DragonSize.MEDIUM:
                hidden = true;
                insideBush = seenBush;
                break;

            case DragonSize.LARGE:
                break;

            default:
                Debug.LogWarning("Dragon Does not have a Size set");
                break;
        }
    }

    /// <summary>
    /// Function handles leaving a bush
    /// </summary>
    public void InteractBushLeave(){
        //Small
        if (size == DragonSize.SMALL){
            hidden = false;
        }
        //Medium
        if (size == DragonSize.MEDIUM)
        {
            hidden = false;
           insideBush = null;
        }
        //Large
        if (size == DragonSize.LARGE)
        {
            insideBush = null;
        }
    }

    /// <summary>
    /// Checks if Character is in contact with a Ground tagged GameObject
    /// </summary>
    public bool IsGrounded()
    // TODO  - Not registering the grounded properly if the ground gameObject does not use the ground layer in the inspector (next to the tag).
    {
        bool isGrounded = Physics.CheckSphere(Bottom.transform.position, 0.3f, groundLayer);
        if (isGrounded) { jumpCount = 1; }
        else {jumpedRecently = true;}
        return Physics.CheckSphere(Bottom.transform.position, 0.3f, groundLayer);
    }

    /// <summary>
    /// WIP. NOTE: does only work when moving forward. Could be performance issue due to calling in update loop
    /// </summary>
    public void CanClimb() {
        RaycastHit hitLower;
        // Colliding with an object at the feet
        if (Physics.Raycast(stepRayLower.transform.position, this.transform.TransformDirection(Vector3.forward), out hitLower, 0.3f, LayerMask.GetMask("Stairs"))) {
           RaycastHit hitHigher;
           // If the same object is not blocking the knees (or whatever the height is set to)
            if (!Physics.Raycast(stepRayHigher.transform.position, transform.TransformDirection(Vector3.forward), out hitHigher, 0.3f)) {
                rigBody.position -= new Vector3(0f, -stepSmooth, 0f);
                return;
            }
        }
    }

    /// <summary>
    /// Disables the detection zone of the guard
    /// </summary>
    public void RoarDragon() {
        // Do not allow consecutive roars
        if (roarUsedRecently)
        {
            return;
        }

        if (canRoar) {
            roarSound.Play();
            foreach (GameObject guardObject in guardObjectsInScene) {
                if (Vector3.Distance(Model.transform.position, guardObject.transform.position) < 10) {
                    roarUsedRecently = true;
                    StartCoroutine(DisableGuardDetectionForATime(guardObject));
                }
            }    
        }
              
    }

    /// <summary>
    /// A seperate thread. Disables the collider detection component of the guard, waits 5 sec, then enables it again. Also changes colour of the
    /// indicator on the ground meanwhile.
    /// </summary>
    IEnumerator DisableGuardDetectionForATime(GameObject guardObject) {
        icons.UpdateRoarUsed(true);
        CapsuleCollider colliderCapsule = guardObject.GetComponent<CapsuleCollider>();
        Renderer renderer = guardObject.GetComponent<Renderer>();
        colliderCapsule.enabled = false;
        //Changes the colour  to white (RBA 0(black - 255 (white))).
        renderer.material.color = guardWhiteColor;

        yield return new WaitForSeconds(5);
        //Changes the colour back.
        colliderCapsule.enabled = true;

        renderer.material.color = guardRedColor;
        // Allow user to roar again
        roarUsedRecently = false;
        icons.UpdateRoarUsed(false);
    }

    /// <summary>
    /// Checks if the dragon is inside a bush and standing stil, if it isnt, its not hidden
    /// </summary>
    private bool IsDragonVisible()
    {
        if (!hidden)
            return true;
        
        if (hidden && rigBody.velocity.magnitude > VelocityHidingThreshold)
            return true;

        return false;
    }

    /// <summary>
    /// Calculates the total amount of money the dragon has
    /// </summary>
    public int calculateTotalMoneyDragon(int score)
    {
        if (size == DragonSize.SMALL){
            return score;
        } else if (size == DragonSize.MEDIUM){
            return score + 2; //Hardcoded should be avoided
        } else if (size == DragonSize.LARGE){
            return score + 5; //Hardcoded should be avoided
        }else{
            Debug.LogError("DragonSize could not be determined. Name: " + name);
            return 0;
        }
    }

    /// <summary>
    /// On trigger enter function
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.CompareTag("Holder")) {}
        else {
        if (other.gameObject.CompareTag("Guard")) {
            GameObject guardObjectField = other.gameObject;
            
            if(IsDragonVisible()) {
                //Checks if the guard object can spot got LOS on the player (obstruction layer blocks view)
                bool canSeePlayerFlag = guard.CheckForLineOfSight(Model, guardObjectField);
                if (canSeePlayerFlag) {
                    IsCaught = true;
                }
            }
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            //Sound
            coinPickUpSound.Play();
            Destroy(other.gameObject);
            //Dragonsize determines if the evolvebar increases or if the score increases
            if (size != DragonSize.LARGE){
                //Updates the global variable
                CoinScore.globalCoinScore += 1;
                evolveBar.UpdateEvolveScore(calculateTotalMoneyDragon(CoinScore.globalCoinScore));
            } else {
                CoinScore.globalTotalCoinScore += 1;
                evolveBar.UpdateScore(CoinScore.globalTotalCoinScore);
            }
            
        }
        if (other.gameObject.CompareTag("Bush")){
            InteractBushEnter(other.gameObject, this.size);
        }
        }
    }

    /// <summary>
    /// On trigger exit function
    /// </summary>
    void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Bush")){
            InteractBushLeave();
        }
    }


}
