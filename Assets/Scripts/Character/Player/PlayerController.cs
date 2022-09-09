using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{   
    [SerializeField] PlayerStatController statController;
    private void Awake()
    {

    }

    private void Update()
    {
        MoveCharacter();
        CheckEvolve();
        CheckCollision();
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

        if(horizontalInput != 0 || verticalInput != 0)
        {
            statController.activeDragon.DoMove(horizontalInput, verticalInput);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            statController.activeDragon.DoJump();
    }

    private void CheckEvolve()
    {
        if (Input.GetKeyDown(KeyCode.E) && statController.CanEvolve())
        {
            statController.DoEvolve();
        }
    }
    
    public void ReloadLevel() {
        Debug.Log("You were caught by the Guard!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

        
}
