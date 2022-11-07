using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void ActivateGlideAnimation() 
    {
        animator.SetBool("isGliding", true);
    }

    public void StopGlideAnimation() 
    {
        animator.SetBool("isGliding", false);
    }

    public void ActivateWalkAnimation() 
    {
        animator.SetBool("isWalking", true);
    }

    public void StopWalkAnimation()
    {
        animator.SetBool("isWalking", false);
    }
}
