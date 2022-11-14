using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    [SerializeField] float size;
    [SerializeField] LayerMask colliderMask;
    [SerializeField] Collider bushCollider;
    [SerializeField] private GameObject self;
    [SerializeField] private Rigidbody rb;

    public bool PlayerIsUsing;

    private void Update()
    {
        if (PlayerIsUsing)
            return;

        if(Physics.CheckSphere(self.transform.position, size, colliderMask))
        {
            rb.useGravity = false;
            rb.velocity = new Vector3(0, 0, 0);
            bushCollider.enabled = true;
            this.enabled = false;
        }   
    }

    public void PickUp()
    {
        rb.isKinematic = true;
        bushCollider.enabled = false;
        PlayerIsUsing = true;
    }
    public void Drop()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
        bushCollider.enabled = true;
        PlayerIsUsing = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(self.transform.position, size);
    }
}
