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
    public float sensitivity = 1f;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Awake()
    {

    }

    private void Update()
    {
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
        /*float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if(horizontalInput != 0 || verticalInput != 0)
        {
            statController.activeDragon.DoMove(horizontalInput, verticalInput);
        }*/

        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        //for up/down/left/right movement of camera.
        //  turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        //for up/down/left/right movement of camera.
        //transform. localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        transform. localRotation = Quaternion.Euler(0, turn.x, 0);

        deltaMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        movement.transform.Translate(deltaMovement);

        if (Input.GetKeyDown(KeyCode.Space))
            statController.activeDragon.DoJump();
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
        //Debug.Log("You were caught by the Guard!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

        
}
