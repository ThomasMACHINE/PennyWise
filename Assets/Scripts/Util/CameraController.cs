using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform trackedObject;

    public float maxDistance;
    public float moveSpeed;
    public float updateSpeed;
    public float currentDistance;
    private GameObject ahead;
    private MeshRenderer _renderer;
    public float hideDistance = 1.5f;
    private int factorOfScaling = 8;
    private float offset = 0;

    void Start()
    {
        ahead = new GameObject("ahead");
        _renderer = trackedObject.gameObject.GetComponent<MeshRenderer>();
    }

    /*
        Most of this code is authored by Unity found at: https://learn.unity.com/tutorial/controlling-unity-camera-behaviour 
    */    

    void LateUpdate()
    {
        GetAheadPosition();
       // ahead.transform.position = trackedObject.position + trackedObject.forward * (maxDistance * 0.25f);
        currentDistance += Input.GetAxisRaw("Mouse ScrollWheel") * moveSpeed * Time.deltaTime * factorOfScaling;
        currentDistance = Mathf.Clamp(currentDistance, 0, maxDistance);
        
        
        transform.position = Vector3.MoveTowards(transform.position, 
                                                 trackedObject.position + Vector3.up * currentDistance - trackedObject.forward * (currentDistance + maxDistance * 0.5f), 
                                                 updateSpeed * Time.deltaTime);
        transform.LookAt(ahead.transform);
        // Hide the player if the draw distance is lower than the hide distance
        _renderer.enabled = currentDistance > hideDistance;
    }

    public void SetNewTarget(GameObject target)
    {
        //Changes how the camera behaviour based on which model is in use. (How far away the camera is and max distance one can go away).
        if (target.name.Contains(nameof(PlayerStatController.GlobalModelENUM.SMALL))) {
            //How far can one scroll away (limit based on puzzles, else free).
            maxDistance = 2;
            //How far away should the camera be (scroll with mousewheel). NOTE; resets on scene changing.
            currentDistance = 1;
        }
        else if (target.name.Contains(nameof(PlayerStatController.GlobalModelENUM.MEDIUM))) {
            maxDistance = 3;
            currentDistance = 2;
        }
        else if (target.name.Contains(nameof(PlayerStatController.GlobalModelENUM.LARGE))) {
            maxDistance = 4;
            currentDistance = 3;
        }
        else {
            Debug.Log("CameraController could not get name of model in use");
        }
        trackedObject = target.transform;
        _renderer = trackedObject.gameObject.GetComponent<MeshRenderer>();

    }

    // Gets the position of the player character. Note that the Y position can be changed. This causes the LookAt to look above the player
    private void GetAheadPosition() {
        if (offset > -1.0f && offset < 3.5f) {
            offset += Input.GetAxis("Mouse Y") * 0.01f;
            // Makes sure that the player can't lock the camera by moving the mouse too fast (causing the offset to surpass the initial limit)
            if (offset <= -1.0f) {
                offset = -0.99f;
            } else if (offset >= 3.5f) {
                offset = 3.49f;
            }
        }
        ahead.transform.position = new Vector3(trackedObject.position.x, trackedObject.position.y + offset, trackedObject.position.z) + trackedObject.forward * (maxDistance * 0.25f);
    }
}