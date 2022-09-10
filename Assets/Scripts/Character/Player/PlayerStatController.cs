using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStatController : MonoBehaviour
{
    // This must be kept in the order of low to highest level dragon
    [SerializeField] LinkedList<Dragon> dragons;
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

    internal void DoEvolve()
    {
        throw new NotImplementedException();
    }
}
