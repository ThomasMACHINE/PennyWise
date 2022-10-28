using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IWalkingCharacter
{
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform eyes;
    [SerializeField] protected Rigidbody rigidBody;
    [SerializeField] protected PlayerStatController playerController;
    [SerializeField] protected float searchRadius;
    [SerializeField] protected int speed;
    [SerializeField] protected CharacterGPS gps;


    public virtual void DoMove()
    {
        Vector3 targetPosition = gps.GetCoordinate(model.position);
        Vector3 direction = (targetPosition - model.position).normalized;
        rigidBody.velocity += new Vector3(direction.x * speed, 0, direction.z * speed);
    }
}
