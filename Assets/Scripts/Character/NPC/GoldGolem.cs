using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldGolem : AggressiveCharacter
{
    [SerializeField] private float size;
    public override void CheckPlayerCaught()
    {
        if (Physics.CheckSphere(model.position, size, playerMask))
        {
            OnPlayerCaught();
        }
    }

    public override void DoMove()
    {
        base.DoMove();
        rigidBody.velocity += new Vector3(0, 2, 0);
    }

    public override void OnPlayerCaught()
    {
        if (Physics.CheckSphere(model.position, 3))
        {
            playerController.RemoveCoin(1);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(model.position, size);
    }
}
