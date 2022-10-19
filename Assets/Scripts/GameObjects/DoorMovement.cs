using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    // shares a lot of functional needs with PlatformMovement.cs, so I took a lot of code/variable names from it

    // kinda want to have pointB defined as an offset instead, but that'd be more work, and inconsistent with the rest of the project
    // could make this and the other Movement both use offset, but that's a breaking change, and those are annoying
    [SerializeField] Vector3 pointB = new Vector3(0,1,0);
    [SerializeField] float openSpeed = 0.5f;
    [SerializeField] float closeSpeed = 2;
    private float speed;
    private Vector3 pointA;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        pointA = this.gameObject.transform.position;
        target = pointA;
        speed = closeSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float step = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }

    // primarily intended to be invoked as an event, see PressurePlate.cs and EventInvokeOnRightClick.cs
    public void setOpen(bool newState){
        if (newState) {
            target = pointB;
            speed = openSpeed;
        } else {
            target = pointA;
            speed = closeSpeed;
        }
    }
}
