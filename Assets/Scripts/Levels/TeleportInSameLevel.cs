using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportInSameLevel : MonoBehaviour {

	// The object that a player should teleport to
	public Transform targetToTeleportTo;
	//The playable object (the one being teleported)
	public GameObject beingTeleported;
	private string playerString = "Player";
	
	// Checks if the player touches/enters the checkpoint.
    private void OnTriggerEnter(Collider other) {
		if(other.tag.Equals(playerString)) {
			TeleportPlayerToTargetObject();
		}
			
	
	}
	//Teleports a player to a pre-designated object.
	//To avoid being stuck, teleports a few unites above the object
	private void TeleportPlayerToTargetObject() {
		//beingTeleported.transform.position = targetToTeleportTo.transform.position;
		beingTeleported.transform.position = new Vector3(targetToTeleportTo.transform.position.x, 
			targetToTeleportTo.transform.position.y + 10, targetToTeleportTo.transform.position.z);
		
	}
}
