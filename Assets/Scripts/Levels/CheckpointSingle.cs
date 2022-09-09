using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSingle : MonoBehaviour {
	void Start() {
		
	}
	void Update() {
		
	}
	
	
    private void OnTriggerEnter(Collider other) {
		if(other.tag.Equals("Player")) {
			Debug.Log("Checkpoint!");
		}
			
		
	/*if (other.TryGetComponent(out Player player)) {
	//	Debug.Log("Checkpoint!");
	} */
	}
}
