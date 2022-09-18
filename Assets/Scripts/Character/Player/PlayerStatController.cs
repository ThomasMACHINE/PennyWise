using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStatController : MonoBehaviour
{
    [SerializeField] CoinDrop coinDropper;
    [SerializeField] CameraController cameraController;
    [SerializeField] public Dragon activeDragon;
    [SerializeField] EvolveBar evolveBar;
    [SerializeField] int coinScore;

    public void Update()
    {
        //TODO This can lead to bugs if evolve is called on the same frame as a coin is picked up and it is called before this Update
        if (activeDragon.UnAccountedCoins != 0)
        {
            coinScore += activeDragon.UnAccountedCoins;
            evolveBar.UpdateSlider((float)coinScore / activeDragon.CoinToEvolve);
            activeDragon.UnAccountedCoins = 0;
        }
    }
/*
    //Test fix for faulty instance. NOTE: should check if the guard "vision" overlap with player position and return true if it does.
    //NullReferenceException: Object reference not set to an instance of an object
    public bool IsCaught() {
        activeDragon.IsCaught = false;
        return activeDragon.IsCaught;
    } */

    public bool CanEvolve() {
        return coinScore >= activeDragon.CoinToEvolve;
    }

    public void DoEvolve()
    {
        //GameObject newDragon = activeDragon.NextDragon;
        coinScore -= activeDragon.CoinToEvolve;
        if(activeDragon.NextDragon == null)
        {
            Debug.Log("There is no higher tier dragon!");
            return;
        }
        SetNewDragon(activeDragon.NextDragon);
    }

    public void DoDevolve() {
        GameObject newDragon = activeDragon.LastDragon;

        if (newDragon == null)
        {
            Debug.Log("There is no lower tier dragon!");
            return;
        }
        // Set the new dragon and drop the coins used to evolve
        SetNewDragon(newDragon);
        coinDropper.DropCoins(newDragon.GetComponent<Dragon>().CoinToEvolve, newDragon.transform.position);
    }

    private void SetNewDragon(GameObject newDragon) {
        activeDragon.gameObject.SetActive(false);
        activeDragon.NextDragon.SetActive(true);
        // Create new dragon and assign old position 
      //  newDragon.gameObject.SetActive(true);
        
        
        newDragon.transform.position = new Vector3(activeDragon.transform.position.x, activeDragon.transform.position.y + 3, activeDragon.transform.position.z);

       
        // Make the camera target the new model
      //  cameraController.SetNewTarget(newDragon);
        activeDragon = newDragon.GetComponent<Dragon>();

        // Set fill bar to appropriate level
        evolveBar.UpdateSlider(coinScore / activeDragon.CoinToEvolve);
    }
}
