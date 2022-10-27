using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] GameObject platformMove;
    
    [SerializeField] Vector3 pointB = new Vector3(0,1,0);
    //time factor
    private float t;
    [SerializeField] float speed = 1;
    private Vector3 pointA;

    [SerializeField] bool active = true;
    [SerializeField] bool loop = true;

    void Start() {
        pointA = this.gameObject.transform.position;
    }
    void Update() {
        if(active) {
            //Makes the pkatform move back and forth
            t += Time.deltaTime * speed;
            // Moves the object to target position
            transform.position = Vector3.Lerp(pointA, pointB, t);
            // Flip the points once it has reached the target
            if (t >= 1 && loop)
            {
            var b = pointB;
            var a = pointA;
            pointA = b;
            pointB = a;
            t = 0;
            }           
        }
    }

    // primarily intended to be invoked as an event, see PressurePlate.cs and EventInvokeOnRightClick.cs
    public void setActiveVariable(bool newState){
        active = newState;
    }
}
