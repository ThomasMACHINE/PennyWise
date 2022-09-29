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

    //Global coinscore.
    public static int localCoinScore;
    //Small dragon 0, medium 1-3, large 3+ TEMP VALUES
    
    //Name of model in use. Need to rework
    public enum GlobalModelENUM
    {
        SMALL, MEDIUM, LARGE
    };
    //Variable to initilize to.
    public static GlobalModelENUM globalModel = GlobalModelENUM.SMALL;
    //Need to change the dragon model from here.
    void Start() {
        Debug.Log(localCoinScore);
        localCoinScore = CoinScore.globalCoinScore;
        Debug.Log(localCoinScore);
          //Checks what kind of model went into the teleporter, and changes the new dragon GameObject to be the same model
          //NOTE, reworking to be caluculated from coinscore could be better.
        if(globalModel == GlobalModelENUM.SMALL) {
         // The dragon initilizes with the small model active.
        }
        else if (globalModel == GlobalModelENUM.MEDIUM) {
            //NOTE: THE NAMING CONVENTION USED  (ADDED IN PREFAB)
            activeDragon.gameObject.transform.parent.Find("Dragon_SMALL").gameObject.SetActive(false);
            activeDragon.gameObject.transform.parent.Find("Dragon_LARGE").gameObject.SetActive(false);
            activeDragon.gameObject.transform.parent.Find("Dragon_MEDIUM").gameObject.SetActive(true);
            SetNewDragon(activeDragon.NextDragon);
        }
        else if (globalModel == GlobalModelENUM.LARGE) {
            activeDragon.gameObject.transform.parent.Find("Dragon_SMALL").gameObject.SetActive(false);
            activeDragon.gameObject.transform.parent.Find("Dragon_MEDIUM").gameObject.SetActive(false);
            activeDragon.gameObject.transform.parent.Find("Dragon_LARGE").gameObject.SetActive(true);
            SetNewDragon(activeDragon.NextDragon);
            SetNewDragon(activeDragon.NextDragon);
        }
        // Need to add a graceful exit here. (should not be able to trigger unless an inspector value is missing or naming convention is wrong)
        else {
            Debug.Log("ERROR IMPENDING. (TO DEV: PLESE MAKE SURE THAT NAMING CONVENTION IS FOLLOWED)!");
        }  
    }
    public void Update()
    {
        //Possible to move out of update?
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
        Debug.Log(activeDragon + ":::ACTIVE DRAGON");
        Debug.Log(newDragon + ":::: NEW DRAGON");
        activeDragon.gameObject.SetActive(false);
        newDragon.SetActive(true);
        Debug.Log(newDragon.name + "was turned on");
        newDragon.transform.position = new Vector3(activeDragon.transform.position.x, activeDragon.transform.position.y + 0.5f, activeDragon.transform.position.z);
       
        // Make the camera target the new model
        cameraController.SetNewTarget(newDragon);
        activeDragon = newDragon.GetComponent<Dragon>();

        // Set fill bar to appropriate level
        evolveBar.UpdateSlider(coinScore / activeDragon.CoinToEvolve);
    }

}
