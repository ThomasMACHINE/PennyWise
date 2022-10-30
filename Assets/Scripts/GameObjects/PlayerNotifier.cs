using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNotifier : MonoBehaviour
{
    public MessagePlayerScreen ui;

    [SerializeField] string TitleText;
    [SerializeField] string BodyText;
    public void MessagePlayer() {
        ui.NotifyPlayer(TitleText, BodyText);
    }
}
