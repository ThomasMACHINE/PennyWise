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
        ahead.transform.position = trackedObject.position + trackedObject.forward * (maxDistance * 0.25f);
        currentDistance += Input.GetAxisRaw("Mouse ScrollWheel") * moveSpeed * Time.deltaTime;
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
        trackedObject = target.transform;
        _renderer = trackedObject.gameObject.GetComponent<MeshRenderer>();

    }
}
