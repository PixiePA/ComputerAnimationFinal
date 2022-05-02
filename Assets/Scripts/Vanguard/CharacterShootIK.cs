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
    bool FireTrigger = false;

    [SerializeField] int id;

    [SerializeField] GameObject Laser;

    public Transform AimTarget;
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
    [SerializeField] GunRotationController gunRotationController;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }

        if (!gunRotationController)
        {
            gunRotationController = GetComponentInChildren<GunRotationController>();
        }

        //VanguardEvents.onGunFired += FireGun;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (AimTarget)
        {
            AimTargetPosition = AimTarget.position;
        }
        gunRotationController.Target = AimTarget;

        GunGripPointPosition = GunGripPoint.position;
        RightHandHintPosition = RightHandHint.position;
        LeftHandHintPosition = LeftHandHint.position;

        if (FireTrigger)
        {
            GunBarrel.LookAt(AimTargetPosition);
            Instantiate(Laser, GunBarrel);
            AimTarget = null;
            FireTrigger = false;
        }
    }

    private void OnAnimatorIK(int layerIndex)
    {
        float weightMultiplier = animator.GetFloat("ikShoot");

        if (AimTarget)
        {
            animator.SetIKPosition(AvatarIKGoal.RightHand, AimTargetPosition);
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, AimWeight * weightMultiplier);
            animator.SetLookAtPosition(AimTargetPosition);
            animator.SetLookAtWeight(weightMultiplier);
        }
        else
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            animator.SetLookAtWeight(0);
        }


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


    }

    public void FireGun()
    {
        FireTrigger = true;
    }
}
