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
    public Rigidbody rigBody { private set; get; }
    private Collider modelCollider;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] public GameObject holder;

    [SerializeField] public int CoinToEvolve;
    [SerializeField] public GameObject LastDragon;
    [SerializeField] public GameObject NextDragon;
    [SerializeField] float characterSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float diveSpeed;
    [SerializeField] EvolveBar evolveBar; //Refactor this
    //[SerializeField] ScoreAndEvolveDisplay display;
    [SerializeField] Abilities icons;
    [SerializeField] Guard guard;

    [SerializeField] GameObject stepRayLower;
    [SerializeField] GameObject stepRayHigher;

    [SerializeField] LayerMask obstructionMask;
    [SerializeField] DragonAnimator characterAnimator;

    // How smooth is the tranition when stepping up.
    [SerializeField] float stepSmooth = 0.5f;
    //Creates a list of gameObjects in scene.
    [SerializeField] private GameObject[] guardObjectsInScene;
    private bool roarUsedRecently;



    public PickUpCrate pickUpController;
    //Bush
    private GameObject insideBush;
    public bool hidden;
    private bool isCarryingBush;
    private Bush heldBush;

    // Bools for dragonabilities
    [SerializeField] bool canGlide;
    [SerializeField] bool canDoubleJump;
    [SerializeField] private int jumpCount;
    [SerializeField] bool canRoar;

    public bool toggleGlide;
    public bool toggleHold;

    public bool IsCaught;
    private Color guardRedColor = new Color(0.840f, 0.000f, 0.043f);
    private Color guardWhiteColor = new Color(255,255,255);

    public enum DragonSize
    {
        none, SMALL, MEDIUM, LARGE
    }

    // Threshold for Guard finding dragon
    private float VelocityHidingThreshold = 0.5f;
    [SerializeField] public DragonSize size;
    
    
    private void Awake() {
        guardObjectsInScene = GameObject.FindGameObjectsWithTag("Guard");
        if (pickUpController) { pickUpController.heldObj = null; }
        modelCollider = GetComponent<Collider>();
        rigBody = GetComponent<Rigidbody>();
        toggleHold = false;
        hidden = false;
    }
    void Start() {
        evolveBar.UpdateScore(CoinScore.globalTotalCoinScore);
    }

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
    }

    /// <summary>
    /// Rotates the model by assigning it a new Quaternion
    /// </summary>
    /// <param name="newQuaternion"></param>
    public void DoRotate(Quaternion newQuaternion) {
        rigBody.MoveRotation(newQuaternion);
        
    }


    // Function for making held objects move with the dragon
    /*
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
    }*/


    //Function for making the dragon drop held items
    public void DropHeldItem () {
        if (pickUpController) 
        { 
            pickUpController.DropObject(); 
        }
        //Dropping crates
        if(holder){
            //pickUpCrate.DropObject();
            
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
    }

    // Function for picking up bush
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

    //Function for making the dragon jump
    public void DoJump()
    {
        
        if(IsGrounded()) {
            jumpCount = 1;
            toggleGlide = false;
            rigBody.velocity = new Vector3(rigBody.velocity.x, jumpSpeed, rigBody.velocity.z);        }
        else {
            // Dragon can glide if it is small size, here it checks to toggle or untoggle it
            if (this.gameObject.name.Contains("SMALL") && Input.GetKeyDown(KeyCode.Space)) {
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
            }
            else {
            }
            
        }
    }

    // Makes Character fall slower - Glide
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

    //Function handles entering a bush
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

    //Function handles leaving a bush
    public void InteractBushLeave(){
        //Small
        if (this.gameObject.name.Contains("SMALL")){
            hidden = false;
        }
        //Medium
        if (this.gameObject.name.Contains("MEDIUM")){
            hidden = false;
           insideBush = null;
        }
        //Large
        if (this.gameObject.name.Contains("LARGE")){
            insideBush = null;
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

    //WIP. NOTE: does only work when moving forward. Could be performance issue due to calling in update loop
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


    // Disables the detection zone of the guard
    public void RoarDragon() {
        // Do not allow consecutive roars
        if (roarUsedRecently)
        {
            return;
        }

        if (canRoar) {
            foreach (GameObject guardObject in guardObjectsInScene) {
                if (Vector3.Distance(Model.transform.position, guardObject.transform.position) < 10) {
                    roarUsedRecently = true;
                    StartCoroutine(DisableGuardDetectionForATime(guardObject));
                }
            }    
        }
              
    }


    // A seperate thread. Disables the collider detection component of the guard, waits 5 sec, then enables it again. Also changes colour of the
    // indicator on the ground meanwhile.
    IEnumerator DisableGuardDetectionForATime(GameObject guardObject) {
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
    }

    private bool IsDragonVisible()
    {
        if (!hidden)
            return true;
        
        if (hidden && rigBody.velocity.magnitude > VelocityHidingThreshold)
            return true;

        return false;
    }

    public int calculateTotalMoneyDragon(int score, string name){
        if (name.Contains("SMALL")){
            return score;
        } else if (name.Contains("MEDIUM")){
            return score + 2; //Hardcoded should be avoided
        } else {
            return score + 5; //Hardcoded should be avoided
        }
    }

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
            Destroy(other.gameObject);
            //Dragonsize determines if the evolvebar increases or if the score increases
            if (size != DragonSize.LARGE){
                //Updates the global variable
                CoinScore.globalCoinScore += 1;
                evolveBar.UpdateEvolveScore(calculateTotalMoneyDragon(CoinScore.globalCoinScore, name));
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

    void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Bush")){
            InteractBushLeave();
        }
    }


}
