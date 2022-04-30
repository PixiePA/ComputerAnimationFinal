using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShootIK : MonoBehaviour
{
    [SerializeField] float AimWeight = 0;
    [SerializeField] float RightHintWeight = 0;
    [SerializeField] float LeftHintWeight = 0;
    [SerializeField] float LeftHandGripWeight = 0;
    [SerializeField] float LeftHandRestingGripWeight = 0;

    [SerializeField] int id;

    [SerializeField] GameObject Laser;

    [SerializeField] Transform AimTarget;
    Vector3 AimTargetPosition;

    [SerializeField] Transform GunGripPoint;
    Vector3 GunGripPointPosition;

    [SerializeField] Transform RightHandHint;
    Vector3 RightHandHintPosition;

    [SerializeField] Transform LeftHandHint;
    Vector3 LeftHandHintPosition;

    [SerializeField] Transform GunBarrel;
    Vector3 GunBarrelPosition;

    [SerializeField] Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }

        //VanguardEvents.onGunFired += FireGun;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AimTargetPosition = AimTarget.position;
        GunGripPointPosition = GunGripPoint.position;
        RightHandHintPosition = RightHandHint.position;
        LeftHandHintPosition = LeftHandHint.position;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        float weightMultiplier = animator.GetFloat("ikShoot");

        animator.SetIKPosition(AvatarIKGoal.RightHand, AimTargetPosition);
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, AimWeight * weightMultiplier);

        animator.SetIKHintPosition(AvatarIKHint.RightElbow, RightHandHintPosition);
        animator.SetIKHintPositionWeight(AvatarIKHint.RightElbow, RightHintWeight * weightMultiplier);

        animator.SetIKPosition(AvatarIKGoal.LeftHand, GunGripPointPosition);

        float LeftHandWeight;

        if (animator.GetFloat("ikLeftHandOnGun") <= 0.5f)
        {
            LeftHandWeight = Mathf.Lerp(0, LeftHandRestingGripWeight, animator.GetFloat("ikLeftHandOnGun") * 2);
        }
        else
        {
            LeftHandWeight = Mathf.Lerp(LeftHandRestingGripWeight, LeftHandGripWeight, (animator.GetFloat("ikLeftHandOnGun") - 0.5f) * 2);
        }

        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, LeftHandWeight);

        animator.SetIKHintPosition(AvatarIKHint.LeftElbow, LeftHandHintPosition);
        animator.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, LeftHintWeight * weightMultiplier);

        animator.SetLookAtPosition(AimTargetPosition);
        animator.SetLookAtWeight(weightMultiplier);
    }

    public void FireGun()
    {
        GunBarrel.LookAt(AimTarget.position);
        Instantiate(Laser, GunBarrel);

    }
}
