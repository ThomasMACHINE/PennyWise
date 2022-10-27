using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGPS : MonoBehaviour
{ 
public List<GameObject> PathObjects;
public GameObject GoalDestination;

[SerializeField] float proximityRequired;

// Counter keeps track of which object in the PathObjects is being targeted
[SerializeField] private int counter;
[SerializeField] private bool positiveDirection;

    void Start()
    {
        GoalDestination = PathObjects[counter];
    }

    /// <summary>
    /// Retrieves the goal destination for the character
    /// </summary>
    /// <param name="characterPosition"></param>
    /// <returns></returns>
    public Vector3 GetCoordinate(Vector3 characterPosition)
    {
        if (goalReached(characterPosition)) 
        {
            getNextDestination();
        }
        return GoalDestination.transform.position;
    }

    private bool goalReached(Vector3 position)
    {
        float distance = (position - GoalDestination.transform.position).magnitude;
        return distance <= proximityRequired;
    }
    /// <summary>
    /// Sets new GoalDestination and rotates character towards it
    /// </summary>
    private void getNextDestination()
    {
        // Counter keeps track of which object in the PathObjects is being targeted
        counter = positiveDirection == true ? counter + 1 : counter - 1;

        // Check if last Point has been reached
        if (counter == PathObjects.Count)
        {
            // Set the goal to the 2nd last object
            counter = PathObjects.Count - 1;
            positiveDirection = false;
        }
        else if (counter == -1)
        {
            counter = 1;
            positiveDirection = true;
        }
        GoalDestination = PathObjects[counter];
    }

    private void OnDrawGizmos()
    {
        foreach (GameObject point in PathObjects)
        {
            Gizmos.DrawSphere(point.transform.position, 0.5f);
        }
    }
}