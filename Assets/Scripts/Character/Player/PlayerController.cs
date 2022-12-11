using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{   
    //Statcontroler
    [SerializeField] PlayerStatController statController;
    //Dragon being used by player at this time
    [SerializeField] Dragon dragon;
    //Variables for movement:
    public Vector2 turn;
    public Vector3 deltaMovement;
    public GameObject movement;
    public float rotationSensitivity = 1f;
    public float speed = 1;

    // World height before restarting the level (falling of the edge of the world)
    private int deathZone = -15;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Time.timeScale == 0) {
            return;
        }
        MoveCharacter();
        stepClimb();
        CheckEvolve();
        CheckCollision();
        CheckRoar();
        ReloadLevelOnCommand();
        CheckBelowLevel();
    }

    /// <summary>
    /// Checks if the player is cought by a guard
    /// </summary>
    private void CheckCollision()
    {
        if (statController.activeDragon.IsCaught) {
            statController.activeDragon.IsCaught = false;
            ReloadLevel();
            
        }
    }

    /// <summary>
    /// Function for making the dragon move in by "WASD" input
    /// </summary>
    private void MoveCharacter()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // If the dragon is not gliding, allow input from WASD
        if (statController.activeDragon.toggleGlide != true){
            statController.activeDragon.DoMove(horizontalInput, verticalInput);
        }
        
        // Check for rotation. NOTE: add time component
        if (Input.GetAxis("Mouse X") != 0)
        {
            turn.x += Input.GetAxis("Mouse X") * rotationSensitivity;
            Quaternion newQuaternion = Quaternion.Euler(0, turn.x, 0);
            statController.activeDragon.DoRotate(newQuaternion);
        }
        //Gliding for the smallest dragon
        statController.activeDragon.DoGlide();

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space)) {
            statController.activeDragon.DoJump();
        }

        if (statController.activeDragon.jumpedRecently == true){
            if (statController.activeDragon.IsGrounded()) {
                statController.activeDragon.landSound.Play();
                statController.activeDragon.jumpedRecently = false;
            }
        }

        //Bush
        statController.activeDragon.UpdateBush();
    }

    /// <summary>
    /// Function to handle walking on stairs
    /// </summary>
    void stepClimb() {
        statController.activeDragon.CanClimb();        
    }

    /// <summary>
    /// Checks if the player wants to shrink the dragon, and if able to do so, performs the action
    /// </summary>
    private void CheckEvolve()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            statController.DoDevolve();
        }
    }

    /// <summary>
    /// Checks if the player wants to reload the level, and performs the action
    /// </summary>
    private void ReloadLevelOnCommand()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    /// <summary>
    /// Checks if the player is currently underneath the deathzone which means the player fell of the map
    /// </summary>
    private void CheckBelowLevel() {
        if (statController.activeDragon.transform.position.y < deathZone) {
            ReloadLevel();
        }
    }

    /// <summary>
    /// Checks if the player wants to roar, and if able to do so, performs the action
    /// </summary>
    private void CheckRoar() { //Should change this button to be E since E no longer evolves the dragon
        if (Input.GetKeyDown(KeyCode.E) && statController.activeDragon.size == Dragon.DragonSize.LARGE) {
            statController.activeDragon.RoarDragon();
            }
        }
    
    /// <summary>
    /// Reloads the level
    /// </summary>
    public static void ReloadLevel() {     
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
