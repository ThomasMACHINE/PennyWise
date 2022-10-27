using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    public UnityEvent smallEvent;
    public UnityEvent mediumEvent;
    public UnityEvent largeEvent;

    public UnityEvent disableEvent;

    // a list to store what is and is not on us
    private List<GameObject> collidedObjects = new List<GameObject>();

       // Checks if the player touches/steps on the pressure plate.
    private void OnTriggerEnter(Collider other) {
		if(other.tag.Equals("Player")) {
            // Could possibly add a container platform so the player is in the middle. Will need the size of the models to effectivly implement.
			Debug.Log("Pressure plate!");
			if (other.gameObject.name.Contains("SMALL")) {
                Debug.Log("Small dragon");
                
                smallEvent.Invoke();
            }
            else if (other.gameObject.name.Contains("MEDIUM")) {
                Debug.Log("Medium dragon");
                mediumEvent.Invoke();
            }
            else if (other.gameObject.name.Contains("LARGE")) {
                Debug.Log("Large dragon");
                largeEvent.Invoke();
            }
            //Should never be able to see this, but you should help with testing.
            else {
                Debug.Log("No valid dragon model entered the pressure plate");
            }
		}
        if(other.tag.Equals("Crate")) {
            smallEvent.Invoke();
        }
        collidedObjects.Add(other.gameObject);
    }
    private void OnTriggerExit(Collider other) {
        collidedObjects.Remove(other.gameObject);
        if(collidedObjects.Count == 0) {
            disableEvent.Invoke();
        }
    }



}
