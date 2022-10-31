using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Messagezone : MonoBehaviour{
    //Variables

    [SerializeField] MessagePlayerScreen messagePlayer;

    [SerializeField] GameObject self;
    [SerializeField] string titleText;
    [SerializeField] string bodyText;

    void sendMessage()
    {
        messagePlayer.NotifyPlayer(titleText, bodyText);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sendMessage();
            self.SetActive(false);
        }
    }

}