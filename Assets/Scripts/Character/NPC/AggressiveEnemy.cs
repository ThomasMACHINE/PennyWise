using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AggressiveEnemy is an interface derived from WalkingCharacter
/// that also implements a search for player
/// </summary>
public interface AggressiveEnemy : WalkingCharacter
{
    /// <summary>
    /// Searches for player
    /// </summary>
    public void SearchForPlayer();
}
