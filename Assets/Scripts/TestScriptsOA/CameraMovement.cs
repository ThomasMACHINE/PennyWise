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
        transform.rotation = Quaternion.Lerp(transform.rotation, cameraTarget.rotation, rotationLerp);
    }

    public void SetNewTarget(GameObject target)
    {
        //Changes how the camera behaviour based on which model is in use. (How far away the camera is and max distance one can go away).
        if (target.name.Contains(nameof(PlayerStatController.GlobalModelENUM.SMALL))) {
            cameraTarget = cameraTargetSmall;
            
        }
        else if (target.name.Contains(nameof(PlayerStatController.GlobalModelENUM.MEDIUM))) {
            cameraTarget = cameraTargetMedium;
        }
        else if (target.name.Contains(nameof(PlayerStatController.GlobalModelENUM.LARGE))) {
            cameraTarget = cameraTargetLarge;
        }
        else {
            // Should not be able to reach here.
            Debug.Log("CameraMovement could not get name of model in use");
        } 
        trackedObject = target.transform;
    }
}
