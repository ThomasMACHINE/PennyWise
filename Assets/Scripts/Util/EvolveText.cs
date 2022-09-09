using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EvolveText : MonoBehaviour
{
    public Text notificationText;

    public void EvolveNotificationEnable()
    {
        notificationText.text = "Press E to evolve!";
    }

    public void EvolveNotificationDisable()
    {
        notificationText.text = "";
    }
}