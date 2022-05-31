using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAnimatiionIKController : ShooterController
{
    Vector3 GrabTargetLocation;
    Transform GrabTargetTransform;
    [SerializeField] Animator vanguardAnimator;

    [SerializeField] Transform hand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GrabTargetTransform)
        {
            GrabTargetLocation = GrabTargetTransform.position;
        }

    }

    protected override void AimAtTarget(int shooterID, Transform target)
    {
        GrabTargetTransform = target;
    }

    public void GrabObject(int id)
    {
        GunEvents.CallTarget(id, shooterID);
        vanguardAnimator.SetTrigger("grab");
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (vanguardAnimator.GetFloat("grabIK") > 0)
        {
            vanguardAnimator.SetIKPosition(AvatarIKGoal.LeftHand, GrabTargetLocation);
            vanguardAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, vanguardAnimator.GetFloat("grabIK"));
        }
    }

    public void TakeObject()
    {
        GrabTargetTransform.position = hand.position;
        GrabTargetTransform.SetParent(hand);
        GrabTargetTransform = null;
    }
}
