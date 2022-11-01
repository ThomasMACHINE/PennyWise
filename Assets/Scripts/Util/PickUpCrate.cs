using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCrate : MonoBehaviour
{
    [SerializeField] private GameObject spottedObj;
    [SerializeField] public GameObject heldObj;
    public Vector3 PrevPos;
    public Vector3 NewPos;
    public Vector3 ObjVelocity;


    private void Awake()
    {
        heldObj = null;
    }
    void Start(){
        PrevPos = transform.position;
   }

    void Update(){
        
        //can only pick up crate within distance
        if (Input.GetKeyDown(KeyCode.C) && spottedObj != null){
            PickupObject(spottedObj);
        }

        //If holding object
        if (heldObj != null){
            //Update movement
            
            MoveObject();
            

            //Dropping the crate
            if (Input.GetKeyDown(KeyCode.V)){
                DropObject();
            }
        }


    }

    //Triggers if the holder overlaps with a crate, setting that crate to be interactable
    void OnTriggerEnter(Collider hit){
        if (hit.gameObject.CompareTag("Crate"))
        {   
            spottedObj = hit.gameObject;
        } 
    }

   //Triggers if the holder exits the overlap with a crate, setting interactables to null
    void OnTriggerExit(Collider hit){
        if (hit.gameObject.CompareTag("Crate"))
        {
            spottedObj = null;
        } 
    }

    //Picking up crate
    public void PickupObject (GameObject pickObj){
        if(pickObj.GetComponent<Rigidbody>()){
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            //objRig.drag = 10;

            objRig.transform.parent = this.transform;
            heldObj = pickObj;
        }

    }

    //Dropping crate
    public void DropObject(){
        if (!heldObj) { return; }

        Rigidbody objRig = heldObj.GetComponent<Rigidbody>();
        objRig.useGravity = true;
        objRig.drag = 1;
        
        heldObj.transform.parent = null;
        heldObj = null;
        spottedObj = null;
    }

    //Updating the object each turn
    void MoveObject(){
        if(Vector3.Distance(heldObj.transform.position, this.transform.position) > 0.1f){
            heldObj.transform.position += (this.transform.position - heldObj.transform.position).normalized * Time.deltaTime;
        }
 
    }
}
