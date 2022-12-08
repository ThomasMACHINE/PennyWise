using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStatController : MonoBehaviour
{
    //Managing the coindrops
    [SerializeField] CoinDrop coinDropper;
    //Camera for the player
    [SerializeField] CameraController cameraController;
    //Current active model
    [SerializeField] public Dragon activeDragon;
    //UI for showing amount of coins collected
    [SerializeField] EvolveBar evolveBar;
    //UI for showing abilities
    [SerializeField] Abilities icons;
    //Int for number of coins collected
    [SerializeField] int coinScore;
    //Dragon
    [SerializeField] Dragon dragon;
    //Sound
    public AudioSource coinDropSound;

    
    //Name of model in use
    public enum GlobalModelENUM
    {
        SMALL, MEDIUM, LARGE
    };
    public static GlobalModelENUM globalModel = GlobalModelENUM.SMALL;

    // Function called at start
    void Start() {
        //Updating coinscore from the globaly saved coinscore
        CoinScore.globalCoinScore = CoinScore.tempGlobalCoinScore;
        CoinScore.globalTotalCoinScore = CoinScore.tempglobalTotalCoinScore;
        
        // Checks what kind of model went into the teleporter, and changes the new dragon GameObject to be the same model
        if(globalModel == GlobalModelENUM.SMALL) {
            evolveBar.UpdateEvolveScore(activeDragon.calculateTotalMoneyDragon(CoinScore.globalCoinScore));
        }
        else if (globalModel == GlobalModelENUM.MEDIUM) {
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
        else {
            Debug.Log("ERROR IMPENDING. (TO DEV: PLESE MAKE SURE THAT NAMING CONVENTION IS FOLLOWED)!");
        }
        //Update UI - AbilityIcons & EvolveBar
        icons.UpdateIcons(activeDragon.name);
        evolveBar.UpdateEvolveScore(activeDragon.calculateTotalMoneyDragon(CoinScore.globalCoinScore));
    }

    //Function running on update
    public void Update()
    {       
        //Checks if the dragon meets the requirement to grow in size, and if it does, updates the player. 
        if (CanEvolve()){ 
            DoEvolve();
        }
    }

    //Test fix for faulty instance. NOTE: should check if the guard "vision" overlap with player position and return true if it does.
    //NullReferenceException: Object reference not set to an instance of an object
    public bool IsCaught() {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns if coinScore is higher than Coins needed to evolve
    /// </summary>
    /// <returns></returns>
    public bool CanEvolve() {
        return CoinScore.globalCoinScore >= activeDragon.CoinToEvolve;
    }

    /// <summary>
    /// Replaces current Player Character by the Next Character
    /// </summary>
    public void DoEvolve()
    {
        CoinScore.globalCoinScore -= activeDragon.CoinToEvolve;
        if(activeDragon.NextDragon == null)
        {
            Debug.Log("There is no higher tier dragon!");
            return;
        }
        SetNewDragon(activeDragon.NextDragon);
    }

    /// <summary>
    /// Replaces current Player Character by the Last Character
    /// </summary>
    public void DoDevolve() {
        // Checks if the player should be able to deevolve (that the are not allready the smallest).
        if (activeDragon.size == Dragon.DragonSize.SMALL) {
            return;
        }
        activeDragon.ResetGuardsAfterDeevolving();
        GameObject newDragon = activeDragon.LastDragon;

        if (newDragon == null)
        {
            Debug.Log("There is no lower tier dragon!");
            return;
        }
        // Set the new dragon and drop the coins used to evolve
        SetNewDragon(newDragon);

        //CoinScore.globalCoinScore -= activeDragon.CoinToEvolve;
        //NOTE: drop coin amount equal to evolve req. (2 for medium -> small, 5 for large -> medium atm)
        //Sound
        coinDropSound.Play();
        coinDropper.DropCoins(newDragon.GetComponent<Dragon>().CoinToEvolve, newDragon.transform.position);
    }

    /// <summary>
    /// Replaces current Player Character by the Last Character when damage is the cause
    /// </summary>
    private void DoDevolveFromDamage() {
        // Checks if the player should be able to deevolve (that the are not allready the smallest).
        if (activeDragon.size == Dragon.DragonSize.SMALL)
        {
            return;
        }
        activeDragon.ResetGuardsAfterDeevolving();
        GameObject newDragon = activeDragon.LastDragon;

        if (newDragon == null)
        {
            Debug.Log("There is no lower tier dragon!");
            return;
        }
        // Set the new dragon and drop the coins used to evolve
        SetNewDragon(newDragon);

        CoinScore.globalCoinScore = activeDragon.CoinToEvolve - 1;
        evolveBar.UpdateEvolveScore(activeDragon.calculateTotalMoneyDragon(CoinScore.globalCoinScore));
    }

    /// <summary>
    /// Changes the model and stats when changing dragons
    /// </summary>
    private void SetNewDragon(GameObject newDragon) {
        //Dropping items 
        activeDragon.DropHeldItem();
        // Set States and Orientation of the new dragon
        activeDragon.gameObject.SetActive(false);
        newDragon.SetActive(true);
        newDragon.transform.position = activeDragon.transform.position + new Vector3(0, 0.5f ,0); // Add a bit of height so that player does not get stuck in ground
        newDragon.transform.rotation = activeDragon.transform.rotation;
        // Make the camera target the new model
        cameraController.SetNewTarget(newDragon);
        activeDragon = newDragon.GetComponent<Dragon>();

        // Set fill bar to appropriate level
        if (activeDragon.CoinToEvolve != 0) {
            evolveBar.UpdateEvolveScore(activeDragon.calculateTotalMoneyDragon(CoinScore.globalCoinScore));
        }
        UpdateAbilityIcons();        
    }

    public void UpdateAbilityIcons()
    {
        icons.UpdateIcons(activeDragon.name);
    }

    /// <summary>
    /// Removes a certain amount of coins from player
    /// </summary>
    /// <param name="amount"></param>
    public void RemoveCoin(int amount)
    {
        if(CoinScore.globalCoinScore == 0)
        {
            if (activeDragon.size == Dragon.DragonSize.SMALL)
            {
                PlayerController.ReloadLevel();
            }
            else
            {
                DoDevolveFromDamage();
            }
        }
        else
        {
            CoinScore.globalCoinScore = amount >= CoinScore.globalCoinScore ? 0 : CoinScore.globalCoinScore - amount;
        }
        evolveBar.UpdateEvolveScore(activeDragon.calculateTotalMoneyDragon(CoinScore.globalCoinScore));
    }
}
