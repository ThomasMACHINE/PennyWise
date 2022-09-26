using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] Rigidbody  rb;
    [SerializeField] BoxCollider boxColl;

    public bool CanBePicked { get; internal set; }

    private void Awake()
    {
        CanBePicked = false;
        rb = GetComponent<Rigidbody>();
        boxColl = GetComponent<BoxCollider>();
    }
    private void OnCollisionEnter(Collision collider)
    {
            // the ground layer
        if (collider.gameObject.layer == 6)
            CanBePicked = true;
        if (collider.gameObject.name != "Floor")
            return;

        CanBePicked = true;
    }
}
