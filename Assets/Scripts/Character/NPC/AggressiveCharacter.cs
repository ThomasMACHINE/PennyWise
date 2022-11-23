using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for any aggressiveCharacter implementation
/// Contains Implementations for search and movement
/// These can be overridden for custom search/movement
/// </summary>
public abstract class AggressiveCharacter : Character, IAggressiveEnemy
{
    [SerializeField] protected LayerMask playerMask;
    public bool IsHunting { get; protected set; }

    public override void DoMove()
    {
        Vector3 targetPosition = IsHunting == true ? playerController.activeDragon.transform.position : gps.GetCoordinate(model.position);
        Vector3 direction = (targetPosition - model.position).normalized;
        model.LookAt(targetPosition);
        rigidBody.velocity += new Vector3(direction.x * speed, 0, direction.z * speed);
    }

    public virtual void SearchForPlayer()
    {
        if (Physics.CheckSphere(model.position, searchRadius, playerMask))
        {
            // Check for line of sight
            Vector3 direction = playerController.activeDragon.transform.position - eyes.position;
            Debug.DrawRay(eyes.position, direction * searchRadius, Color.yellow, 1);

            RaycastHit hit;
            if (Physics.Raycast(eyes.position, direction, out hit, searchRadius, playerMask)) // The tilda is a fancy way to invert the bitmask of the layerMask (Checking for collision with anything that is not player)
            {
                Debug.Log("Hello I can see u");
                Debug.Log(hit.collider.gameObject.name);
                IsHunting = true;
            }
        } // If player is outside searchRadius
        else
        {
            IsHunting = false;
        }
    }

    public abstract void CheckPlayerCaught();

    public abstract void OnPlayerCaught();
}
