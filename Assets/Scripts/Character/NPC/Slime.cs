using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, AggressiveEnemy
{
    [SerializeField] private GameObject model;
    [SerializeField] private GameObject eyes;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private PlayerStatController playerController;
    [SerializeField] private float searchRadius;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private PathWalker pathWalker;

    [SerializeField] private int speed, jumpPower;
    public bool isHunting { get; private set; }
    
    //Later we can put this in a larger controller that can act as a hive mind for all AI
    [SerializeField] private float moveCooldown = 0;
    [SerializeField] private float searchCooldown = 0;

    private float moveTimer = 0;
    private float searchTimer = 0;
    public void searchForPlayer()
    {
        if (Physics.CheckSphere(model.transform.position, searchRadius, playerMask))
        {
            // Check for line of sight
            Vector3 direction =  playerController.activeDragon.transform.position - eyes.transform.position;
            RaycastHit hit;
            Debug.DrawRay(eyes.transform.position, direction * searchRadius, Color.yellow, searchTimer);

            if (Physics.Raycast(eyes.transform.position, direction, out hit, searchRadius, ~playerMask)) // The tilda is a fancy way to invert the bitmask of the layerMask (Checking for collision with anything that is not player)
            {
                isHunting = true;
                pathWalker.isBusy = true;
            }
        } // If player is outside searchRadius
        else
        {
            isHunting = false;
            pathWalker.isBusy = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveTimer += Time.deltaTime;
        searchTimer += Time.deltaTime;

        if(moveTimer > moveCooldown)
        {
            DoMove();
            moveTimer = 0;
        }

        if(searchTimer > searchCooldown) 
        {
            searchForPlayer();
            searchTimer = 0;
        }
    }

    public void DoMove()
    {
        if (isHunting) 
        {
            Vector3 direction = playerController.activeDragon.transform.position - model.transform.position;
            direction = direction.normalized;

            rigidBody.velocity += new Vector3(direction.x * speed, jumpPower, direction.z * speed);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(model.transform.position, searchRadius);
    }
}

