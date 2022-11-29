/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//NOTE:  NOT IN USE

//Moves the player around by using the mouse.
public class mouseController : MonoBehaviour
{

    public Vector2 turn;
    public Vector3 deltaMovement;
    public GameObject movement;
    public float sensitivity = 1f;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        //for up/down/left/right movement of camera.
      //  turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        //for up/down/left/right movement of camera.
        //transform. localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        transform. localRotation = Quaternion.Euler(0, turn.x, 0);

        deltaMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        movement.transform.Translate(deltaMovement);
    }
}*/
