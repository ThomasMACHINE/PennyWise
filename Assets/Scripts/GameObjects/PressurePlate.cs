using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    // Which dragon size can interact with the PressurePlate (only one)
    [SerializeField] bool smallImage;
    [SerializeField] bool mediumImage;
    [SerializeField] bool largeImage;
    // The canvas image object.
    [SerializeField] GameObject imageGameObject;

    //S prites from the 2d folder
    [SerializeField] Sprite smallImageSprite;
    [SerializeField] Sprite mediumImageSprite;
    [SerializeField] Sprite largeImageSprite;

    public UnityEvent smallEvent;
    public UnityEvent mediumEvent;
    public UnityEvent largeEvent;

    public UnityEvent disableEvent;

    // a list to store what is and is not on us
    private List<GameObject> collidedObjects = new List<GameObject>();


    void Start() {
        //Checks if only one image state has been set to true in the inspector
        if (smallImage && !(mediumImage || largeImage)) {
        
            imageGameObject.GetComponent<UnityEngine.UI.Image>().sprite = smallImageSprite;

        }
        else if (mediumImage && !(smallImage || largeImage)) {
            Debug.Log("Not implemented medium sprite img...yet;");
            imageGameObject.GetComponent<UnityEngine.UI.Image>().sprite = mediumImageSprite;
        }
        else if (largeImage && !(smallImage || mediumImage)) {
            Debug.Log("Not implemented large sprite img...yet;");
            imageGameObject.GetComponent<UnityEngine.UI.Image>().sprite = largeImageSprite;
        }
        else {
            Debug.Log("ERROR! Either no image was choosen for the PressurePlate or more than one was set to true");
        }
    }

    

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
