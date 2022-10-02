using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    
    public Transform theDest;

    public void Hold(){
        //GetComponent<Rigidbody>().useGravity = false;
        //GetComponent<Rigidbody>().freezeRotation = true;
        //this.transform.position = Vector3.MoveTowards(GameObject.Find("Holder").position, theDest.position, 1 * Time.fixedDeltaTime);
        this.transform.position = theDest.position;
        
        //Moves and rotates with parent object
        this.transform.parent = GameObject.Find("Holder").transform;
    }

    public void Drop(){
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }

    
}
