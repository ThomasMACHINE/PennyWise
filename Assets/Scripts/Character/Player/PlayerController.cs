using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{   
    [SerializeField] PlayerStatController statController;
    public Vector2 turn;
    public Vector3 deltaMovement;
    public GameObject movement;
    public float rotationSensitivity = 1f;
    public float speed = 1;

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
        CheckEvolve();
        CheckCollision();
        ReloadLevelOnCommand();
    }

    private void CheckCollision()
    {
        if (statController.activeDragon.IsCaught) {
            statController.activeDragon.IsCaught = false;
            ReloadLevel();
            
        }
    }

    private void MoveCharacter()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Check for movement
        if(horizontalInput != 0 || verticalInput != 0)
        {
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

    }

    private void CheckEvolve()
    {
        if (Input.GetKeyDown(KeyCode.E) && statController.CanEvolve())
        {
            
            statController.DoEvolve();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            
            statController.DoDevolve();
        }
    }

    private void ReloadLevelOnCommand()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("You reloaded the level!");
            ReloadLevel();
        }
    }
    
    public void ReloadLevel() {     
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
