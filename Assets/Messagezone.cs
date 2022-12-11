using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Messagezone : MonoBehaviour{
    //Variables

    [SerializeField] MessagePlayerScreen messagePlayer;

    [SerializeField] GameObject self;
    [SerializeField] string titleText;
    [SerializeField] string bodyText;
    private string playerString = "Player";

    void sendMessage()
    {
        messagePlayer.NotifyPlayer(titleText, bodyText);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerString))
        {
            sendMessage();
            self.SetActive(false);
        }
    }

}