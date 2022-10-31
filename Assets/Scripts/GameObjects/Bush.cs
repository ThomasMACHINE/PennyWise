using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    [SerializeField] float size;
    [SerializeField] LayerMask colliderMask;

    [SerializeField] private GameObject self;
    [SerializeField] private Rigidbody rb;

    private void Update()
    {
        if(Physics.CheckSphere(self.transform.position, size, colliderMask))
        {
            rb.useGravity = false;
            rb.velocity = new Vector3(0, 0, 0);
        }   
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(self.transform.position, size);
    }
}
