using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    // [SerializeField] float detectionRange;
    [SerializeField] bool usesPathWalker = false;
    //Needed to move the object when not using the pathwalker script
    [SerializeField] Vector3 pointA = new Vector3(3,0,0); 
    [SerializeField] Vector3 pointB = new Vector3(0,0,0);
    [SerializeField] float speed = 1;
    // time
    private float t;

    [SerializeField] PlayerController player;
    [SerializeField] LayerMask playerMask;
    [SerializeField] LayerMask obstructionMask;
    [SerializeField] PathWalker walkController;
    
    // Update is called once per frame
    void Update()
    {
        // If you dont want to use this, just set this field to false in the inspector on Unity.
        if (usesPathWalker == true) { return; }
        //Makes the guard move back and forth
        t += Time.deltaTime * speed;
        // Moves the object to target position
        transform.position = Vector3.Lerp(pointA, pointB, t);
        // Flip the points once it has reached the target
        if (t >= 1)
        {
        var b = pointB;
        var a = pointA;
        pointA = b;
        pointB = a;
        t = 0;
        }   
    }

    // Checks for LOS from the guard object to the player. Obstuction layer objects block view
    public bool CheckForLineOfSight(GameObject dragonModel, GameObject guardObjectField) {
        int index = guardObjectField.transform.GetSiblingIndex();
        GameObject guardObjectBox = guardObjectField.gameObject.transform.parent.GetChild(index - 1).gameObject;
        if (Physics.Linecast(guardObjectBox.transform.position, dragonModel.transform.position, obstructionMask)) {
            return false;
        }
        return true;
    }
     
}
