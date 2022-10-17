using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
       // Checks if the player touches/steps on the pressure plate.
    private void OnTriggerEnter(Collider other) {
		if(other.tag.Equals("Player")) {
            // Could possibly add a container platform so the player is in the middle. Will need the size of the models to effectivly implement.
			Debug.Log("Pressure plate!");
			if (other.gameObject.name.Contains("SMALL")) {
                
                Debug.Log("Small dragon");
            }
            else if (other.gameObject.name.Contains("MEDIUM")) {
                Debug.Log("Medium dragon");
                
            }
            else if (other.gameObject.name.Contains("LARGE")) {
                Debug.Log("Large dragon");
            }
            //Should never be able to see this, but you should help with testing.
            else {
                Debug.Log("No valid dragon model entered the pressure plate");
            }
		}
    }
    private void OnTriggerExit(Collider other) {
        //other.gameObject

    }



}
