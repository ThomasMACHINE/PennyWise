using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] Rigidbody  rb;
    [SerializeField] BoxCollider boxColl;
    private string playerString = "Player";
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        boxColl = GetComponent<BoxCollider>();
    }
    // Makes the player able to pick up coins dropped from deevolvin
    private void OnCollisionEnter(Collision collider)
    {
            // Checks if the player is the one picking up the coins. Until then, the coin is unpickable (Can be moved by physics)
            // Stops the coins from falling trough the world, not falling down to the ground and/or coins clinging to each other 
            //(thus causing them to be stuck in the loop until seperated).
        if (collider.gameObject.tag == playerString) {
            Destroy(rb);
            boxColl.isTrigger = true;
            }
    }
}
