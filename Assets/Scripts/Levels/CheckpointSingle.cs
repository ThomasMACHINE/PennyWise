using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSingle : MonoBehaviour {

	// The object that a player should teleport to
	public Transform targetToTeleportTo;
	//The playable object (the one being teleported)
	public GameObject beingTeleported;
	
	// Checks if the player touches/enters the checkpoint.
    private void OnTriggerEnter(Collider other) {
		if(other.tag.Equals("Player")) {
			Debug.Log("Checkpoint!");
			TeleportPlayerToTargetObject();
		}
			
	//Teleports a player to a pre-designated object.
	//To avoid being stuck, teleports a few meters(?) above the object. NOTE: Need to adjust from the CENTER of the object (so flat objects is the best)
	void TeleportPlayerToTargetObject() {
		//beingTeleported.transform.position = targetToTeleportTo.transform.position;
		beingTeleported.transform.position = new Vector3(targetToTeleportTo.transform.position.x, 
			targetToTeleportTo.transform.position.y + 3, targetToTeleportTo.transform.position.z);
		
	}
	/*if (other.TryGetComponent(out Player player)) {
	//	Debug.Log("Checkpoint!");
	} */
	}
}
