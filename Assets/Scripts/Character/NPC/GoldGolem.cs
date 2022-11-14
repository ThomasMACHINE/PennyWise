using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldGolem : AggressiveCharacter
{
    [SerializeField] private float size;
    [SerializeField] private MessagePlayerScreen playerMessage;
    private bool firstTimePlayerCatch = false;

    [SerializeField] Vector3 HitBoxOffSet;
    public override void CheckPlayerCaught()
    {
        if (Physics.CheckSphere(model.position + HitBoxOffSet, size, playerMask))
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
        playerController.RemoveCoin(1);
       
        if (!firstTimePlayerCatch)
        {
            firstTimePlayerCatch = false;
            playerMessage.NotifyPlayer("Slime Monster", "The slime monster removes a gold piece from the player when caught. So make sure to avoid it!");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(model.position + HitBoxOffSet, size);
    }
}
