using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldGolem : AggressiveCharacter
{
    [SerializeField] private float size;
    [SerializeField] private MessagePlayerScreen playerMessage;

    [SerializeField] Vector3 HitBoxOffSet;
    [SerializeField] Animator eatCoinAnimation;
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
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    public override void OnPlayerCaught()
    {
        eatCoinAnimation.Play("EatCoin", 0, 0f);
        playerController.RemoveCoin(1);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(model.position + HitBoxOffSet, size);
    }
}
