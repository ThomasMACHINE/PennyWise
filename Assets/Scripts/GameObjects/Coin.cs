using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] Rigidbody  rb;
    [SerializeField] BoxCollider boxColl;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        boxColl = GetComponent<BoxCollider>();
    }
    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.name != "Floor")
            return;

        //Turn of physics and enable the boxCollider
        rb.useGravity = false;
        boxColl.isTrigger = true;
    }
}
