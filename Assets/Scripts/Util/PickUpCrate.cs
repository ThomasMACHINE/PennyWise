using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCrate : MonoBehaviour
{
    private GameObject spottedObj;
    private GameObject heldObj;
    public Vector3 PrevPos;
    public Vector3 NewPos;
    public Vector3 ObjVelocity;
    
    
   void Start(){
        PrevPos = transform.position;
   }

    void Update(){
        
        //can only pick up crate within distance
        if (Input.GetKeyDown(KeyCode.C) && spottedObj != null){
            Debug.Log("Picked crate");
            PickupObject(spottedObj);
        }

        //If holding object
        if (heldObj != null){
            //Update movement
            
            MoveObject();
            

            //Dropping the crate
            if (Input.GetKeyDown(KeyCode.V)){
                Debug.Log("Dropped crate");
                DropObject();
            }
        }


    }

    //Triggers if the holder overlaps with a crate, setting that crate to be interactable
    void OnTriggerEnter(Collider hit){
        if (hit.gameObject.CompareTag("Crate"))
        {   
            Debug.Log("Seeing crate");
            spottedObj = hit.gameObject;
        } 
        Debug.Log("Seeing");
    }

   //Triggers if the holder exits the overlap with a crate, setting interactables to null
    void OnTriggerExit(Collider hit){
        if (hit.gameObject.CompareTag("Crate"))
        {
            Debug.Log("Not seeing crate");
            spottedObj = null;
        } 
    }

    //Picking up crate
    void PickupObject (GameObject pickObj){
        if(pickObj.GetComponent<Rigidbody>()){
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            //objRig.drag = 10;

            objRig.transform.parent = this.transform;
            heldObj = pickObj;
        }

    }

    //Dropping crate
    void DropObject(){
        Rigidbody objRig = heldObj.GetComponent<Rigidbody>();
        objRig.useGravity = true;
        objRig.drag = 1;

        heldObj.transform.parent = null;
        heldObj = null;

    }

    //Updating the object each turn
    void MoveObject(){
        if(Vector3.Distance(heldObj.transform.position, this.transform.position) > 0.1f){
            Vector3 moveDirection = (this.transform.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * 100);
        }
    }

}
