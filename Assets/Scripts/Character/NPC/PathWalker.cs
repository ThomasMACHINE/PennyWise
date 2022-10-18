using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Takes in a list of gameobjects and moves sequentially throughout their locations
/// </summary>
public class PathWalker : MonoBehaviour
{
    public bool isBusy;
    public List<GameObject> PathObjects;
    public GameObject GoalDestination;

    // Closeness required before destination is reached
    [SerializeField] private GameObject character;
    [SerializeField] float proximityRequired;

    [SerializeField] private int counter;
    [SerializeField] private bool positiveDirection;
    [SerializeField] private float speed;
    void Start()
    {
        GoalDestination = PathObjects[counter];
    }

    void Update()
    {
        if (isBusy)
            return;

        float distance = (character.transform.position - GoalDestination.transform.position).magnitude;
        // If Character is within the proximity of the goal
        if (distance < proximityRequired) {
            getNextDestination();    
        }
        float step = speed * Time.deltaTime;
        character.transform.position = Vector3.MoveTowards(transform.position, GoalDestination.transform.position, step);
    }

    /// <summary>
    /// Sets new GoalDestination and rotates character towards it
    /// </summary>
    private void getNextDestination() {
        // Counter keeps track of which object in the PathObjects is being targeted
        counter = positiveDirection == true ? counter + 1 : counter - 1;
        Debug.Log(counter + " This is counter value!");

        // Check if last Point has been reached
        if (counter == PathObjects.Count)
        {
            Debug.Log("Going the other way!");
            // Set the goal to the 2nd last object
            counter = PathObjects.Count - 1;
            positiveDirection = false;

        } // Check if first object has been reached
        else if (counter == -1) 
        {
            Debug.Log("Going the POSITIVE WAY!");
            counter = 1;
            positiveDirection = true;
        }
        GoalDestination = PathObjects[counter]; 
        character.transform.LookAt(GoalDestination.transform.position);
    }

}
