using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    
    public Transform theDest;

    public void Hold(){
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = theDest.position;
        this.transform.parent = GameObject.Find("Holder").transform;
    }

    public void Drop(){
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }

    
}
