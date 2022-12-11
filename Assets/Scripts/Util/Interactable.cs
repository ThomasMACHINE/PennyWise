using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    
    public Transform theDest;
    private string holderString = "Holder";

    public void Hold(){
        this.transform.position = theDest.position;
        
        //Moves and rotates with parent object
        this.transform.parent = GameObject.Find(holderString).transform;
    }

    public void Drop(){
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }

    
}
