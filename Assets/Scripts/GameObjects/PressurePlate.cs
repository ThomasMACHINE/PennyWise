using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    // Which dragon size can interact with the PressurePlate
    [SerializeField] dragonType dragonSize;
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

    void Start() {
        switch (dragonSize)
        {
            case dragonType.small:
                imageGameObject.GetComponent<UnityEngine.UI.Image>().sprite = smallImageSprite;
                break;
            case dragonType.medium:
                imageGameObject.GetComponent<UnityEngine.UI.Image>().sprite = mediumImageSprite;
                break;
            case dragonType.large:
                imageGameObject.GetComponent<UnityEngine.UI.Image>().sprite = largeImageSprite;
                break;
        }
    }

    

    // Checks if the player touches/steps on the pressure plate.
    private void OnTriggerEnter(Collider other) {
		if(other.tag.Equals("Player")) {
            // Could possibly add a container platform so the player is in the middle. Will need the size of the models to effectivly implement.
			if (other.gameObject.name.Contains("SMALL")) {
                smallEvent.Invoke();
            }
            else if (other.gameObject.name.Contains("MEDIUM")) {
                mediumEvent.Invoke();
            }
            else if (other.gameObject.name.Contains("LARGE")) {
                largeEvent.Invoke();
            }
            //Should never be able to see this, but you should help with testing.
            else {
                Debug.LogError("No valid dragon model entered the pressure plate");
            }
		}
    }
    // Clean up. Can't see what the intent is here.
    // If the player leaves the platform, disable the invoke. (Crate not counting here)
    private void OnTriggerExit(Collider other) {
        disableEvent.Invoke();
    }



}
