using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldGolem : AggressiveCharacter
{
    [SerializeField] private float size;
    [SerializeField] private MessagePlayerScreen playerMessage;
    private bool firstCatch = false;
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
        if (!firstCatch)
        {
            firstCatch = false;
            playerMessage.NotifyPlayer("Slime Monster", "The slime monster removes a gold piece from the player when caught. So make sure to avoid it!");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(model.position, size);
    }
}
