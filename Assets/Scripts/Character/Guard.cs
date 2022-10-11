using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
   // [SerializeField] float detectionRange;

    //Needed to move the object
    [SerializeField] Vector3 pointA = new Vector3(3,0,0); 
    [SerializeField] Vector3 pointB = new Vector3(0,0,0);
    [SerializeField] float speed = 1;
    //??
    private float t;

    //Temp
    //float degreesPerSecond = 20;

   // [SerializeField] Transform playerModel;
    [SerializeField] PlayerController player;
    [SerializeField] LayerMask playerMask;
    [SerializeField] LayerMask obstructionMask;
    [SerializeField] Transform guardObject;

    
    // Start is called before the first frame update
    void Start()
    {
        //Why is this used?
       // playerModel = GameObject.Find("Player").transform;
        
        //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Locks the guard so it cannot rotate in the z-axis
        
        
        //Rotering
        //transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);

        

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

    // Checks for LOS from the guard object to the player. Obstuction layer objects block view.
    public bool CheckForLineOfSight(GameObject dragonModel) {
        if (Physics.Linecast(guardObject.transform.position, dragonModel.transform.position, obstructionMask)) {
            Debug.Log("No line of sight to the player");
            return false;
        }
        return true;
    }
     
}
