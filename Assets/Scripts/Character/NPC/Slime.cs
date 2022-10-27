using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IAggressiveEnemy
{
    [SerializeField] private MeshRenderer modelRenderer;
    [SerializeField] private Transform model;
    [SerializeField] private Transform eyes;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private PlayerStatController playerController;
    [SerializeField] private float searchRadius;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private int speed, jumpPower;
    [SerializeField] private CharacterGPS gps;

    [SerializeField] private Material idleSkin, aggressiveSkin;

    public bool isHunting { get; private set; }
    
    //Later we can put this in a larger controller that can act as a hive mind for all AI
    [SerializeField] private float moveCooldown = 1;
    [SerializeField] private float searchCooldown = 1;

    private float moveTimer = 0;
    private float searchTimer = 0;

    void Update()
    {
        moveTimer += Time.deltaTime;
        searchTimer += Time.deltaTime;

        if (moveTimer > moveCooldown)
        {
            DoMove();
            moveTimer = 0;
        }

        if (searchTimer > searchCooldown)
        {
            SearchForPlayer();
            searchTimer = 0;
        }
    }

    public void SearchForPlayer()
    {
        if (Physics.CheckSphere(model.position, searchRadius, playerMask))
        {
            // Check for line of sight
            Vector3 direction =  playerController.activeDragon.transform.position - eyes.position;
            RaycastHit hit;
            Debug.DrawRay(eyes.position, direction * searchRadius, Color.yellow, searchTimer);

            if (Physics.Raycast(eyes.position, direction, out hit, searchRadius, ~playerMask)) // The tilda is a fancy way to invert the bitmask of the layerMask (Checking for collision with anything that is not player)
            {
                isHunting = true;
                modelRenderer.material = aggressiveSkin;
            }
        } // If player is outside searchRadius
        else
        {
            isHunting = false;
            modelRenderer.material = idleSkin;
        }
    }

    public void DoMove()
    {
        Vector3 targetPosition = isHunting == true ? playerController.activeDragon.transform.position : gps.GetCoordinate(model.position);
        Vector3 direction = (targetPosition - model.position).normalized; 
        rigidBody.velocity += new Vector3(direction.x * speed, jumpPower, direction.z * speed);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(model.position, searchRadius);
    }
}

