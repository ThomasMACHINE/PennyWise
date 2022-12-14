using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AggressiveEnemy is an interface derived from WalkingCharacter
/// that also implements a search for player
/// </summary>
public interface IAggressiveEnemy : IWalkingCharacter
{
    /// <summary>
    /// Searches for player
    /// </summary>
    public void SearchForPlayer();
    public abstract void CheckPlayerCaught();
    public abstract void OnPlayerCaught();
}
