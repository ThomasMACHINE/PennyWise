using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldGolem : AggressiveCharacter
{
    [SerializeField] private float size;
    [SerializeField] private MessagePlayerScreen playerMessage;
    private bool firstTimePlayerCatch = false;

    [SerializeField] GameObject TransformationOfModel;
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
        TransformationOfModel.transform.position = model.transform.position;
        TransformationOfModel.transform.LookAt(playerController.activeDragon.transform.position);
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
        Gizmos.DrawSphere(model.position, size);
    }
}
