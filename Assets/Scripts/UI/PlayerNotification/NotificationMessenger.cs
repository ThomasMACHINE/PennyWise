using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationMessenger : MonoBehaviour
{
    public enum Messenger
    {
        none,
        Dragon,
        GoldGolem
    };

    [SerializeField]
    public
        Sprite
        none,
        Dragon,
        GoldGolem;

    public Sprite GetMessenger(Messenger messenger)
    {
        switch (messenger)
        {
            case Messenger.Dragon:
                return Dragon;

            case Messenger.GoldGolem:
                return GoldGolem;

            default:
                return none;
        }
    }
}
