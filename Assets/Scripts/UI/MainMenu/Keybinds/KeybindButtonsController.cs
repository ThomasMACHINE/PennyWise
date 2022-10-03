using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeybindButtonsController : MonoBehaviour
{
    [SerializeField] UserControlConstants UserControls;
    Button activeButton;

    internal string Get(UserControlConstants.Keybinds keybindType)
    {
        return UserControls.Get(keybindType);
    }
}
