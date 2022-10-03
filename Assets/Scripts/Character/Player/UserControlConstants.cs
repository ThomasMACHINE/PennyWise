using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Do not use yet
/// </summary>
public class UserControlConstants : MonoBehaviour
{
    public KeyCode ReloadLevel;
    // Character Action commands
    public KeyCode Evolve;
    public KeyCode Devolve;
    public KeyCode Glide;
    public KeyCode Hold;

    public enum Keybinds {
        Null = 0,
        // Level Specific commands
        ReloadLevel,
        // Character Action commands
        Evolve,
        Devolve,
        Glide,
        Hold,
    }


    public string Get(Keybinds keybindType)
    {
        switch (keybindType) {
            case Keybinds.Null:
                throw new ArgumentNullException("Can't pass null ");

            case Keybinds.ReloadLevel:
                return ReloadLevel.ToString();
            case Keybinds.Evolve:
                return Evolve.ToString();
            case Keybinds.Devolve:
                return Devolve.ToString();
            case Keybinds.Glide:
                return Glide.ToString();
            case Keybinds.Hold:
                return Hold.ToString();
            default:
                throw new ArgumentException("Enum is not implemented in UserControlConstant");
        }
    }
    /// <summary>
    /// Sets the key of a User Keybind
    /// </summary>
    /// <param name="keybindType"></param>
    /// <param name="keycode"></param>
    /// <returns></returns>
    public bool Set(Keybinds keybindType, KeyCode keycode)
    {
        if (keycode == KeyCode.None)
            return false;

        switch (keybindType)
        {
            case Keybinds.Null:
                throw new ArgumentNullException("Cannot pass as KeyCode");

            case Keybinds.ReloadLevel:
                ReloadLevel = keycode;
                return true;

            case Keybinds.Evolve:
                Evolve = keycode;
                return true;

            case Keybinds.Devolve:
                Devolve = keycode;
                return true;
            
            case Keybinds.Glide:
                Glide = keycode;
                return true;
            
            case Keybinds.Hold:
                Hold = keycode;
                return true;

            default:
                throw new ArgumentException("Enum is not implemented in UserControlConstant");
        }
    }

    private void Awake()
    {
        ReloadLevel = KeyCode.R;

        Evolve = KeyCode.E;
        Devolve = KeyCode.Q;
        Glide = KeyCode.C;
        Hold = KeyCode.H;
    }
}
