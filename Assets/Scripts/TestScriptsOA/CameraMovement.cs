using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform trackedObject;
    public Transform cameraTarget;
    //references
    public Transform cameraTargetSmall;
    public Transform cameraTargetMedium;
    public Transform cameraTargetLarge;

    public float positionLerp = 5f;
    public float rotationLerp = 3;



  
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, cameraTarget.position, positionLerp);
        //transform.position = new Vector3(transform.position.X, transform.position.Y, transform.position.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, cameraTarget.rotation, rotationLerp);
    }

    public void SetNewTarget(GameObject target)
    {
        Debug.Log("Got inside the SetNewTarget");
        //Changes how the camera behaviour based on which model is in use. (How far away the camera is and max distance one can go away).
        if (target.name.Contains(nameof(PlayerStatController.GlobalModelENUM.SMALL))) {
           /* //How far can one scroll away (limit based on puzzles, else free).
            maxDistance = 2;
            //How far away should the camera be (scroll with mousewheel). NOTE; resets on scene changing.
            currentDistance = 1;*/
            cameraTarget = cameraTargetSmall;
            
        }
        else if (target.name.Contains(nameof(PlayerStatController.GlobalModelENUM.MEDIUM))) {
            /*maxDistance = 3;
            currentDistance = 2;
            */
            cameraTarget = cameraTargetMedium;
        }
        else if (target.name.Contains(nameof(PlayerStatController.GlobalModelENUM.LARGE))) {
            /*maxDistance = 4;
            currentDistance = 3;
            */
            cameraTarget = cameraTargetLarge;
        }
        else {
            Debug.Log("CameraMovement could not get name of model in use");
        } 
        trackedObject = target.transform;
    }
}
