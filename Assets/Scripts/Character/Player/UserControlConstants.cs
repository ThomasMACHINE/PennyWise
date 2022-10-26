using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Do not use yet
/// </summary>
public class UserControlConstants : MonoBehaviour
{

    // Keybinds
    public KeyCode 
    ReloadLevel,
    // Character Action commands
    Evolve,
    Devolve,
    Glide,
    Hold,
    Roar;
    

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



    private void Awake()
    {
        ReloadLevel = KeyCode.R;
        Evolve = KeyCode.E;
        Devolve = KeyCode.Q;
        Glide = KeyCode.C;
        Hold = KeyCode.H;
    }
}
