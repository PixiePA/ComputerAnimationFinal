using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShootIK : MonoBehaviour
{
    [SerializeField] float AimWeight = 0;
    [SerializeField] float RightHintWeight = 0;
    [SerializeField] float LeftHintWeight = 0;
    [SerializeField] float LeftHandGripWeight = 0;

    [SerializeField] Transform AimTarget;
    Vector3 AimTargetPosition;

    [SerializeField] Transform GunGripPoint;
    Vector3 GunGripPointPosition;

    [SerializeField] Transform RightHandHint;
    Vector3 RightHandHintPosition;

    [SerializeField] Transform LeftHandHint;
    Vector3 LeftHandHintPosition;

    [SerializeField] Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }
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
        animator.SetIKPosition(AvatarIKGoal.RightHand, AimTargetPosition);
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, AimWeight);

        animator.SetIKHintPosition(AvatarIKHint.RightElbow, RightHandHintPosition);
        animator.SetIKHintPositionWeight(AvatarIKHint.RightElbow, RightHintWeight);

        animator.SetIKPosition(AvatarIKGoal.LeftHand, GunGripPointPosition);
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, LeftHandGripWeight);

        animator.SetIKHintPosition(AvatarIKHint.LeftElbow, LeftHandHintPosition);
        animator.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, LeftHintWeight);

        animator.SetLookAtPosition(AimTargetPosition);
        animator.SetLookAtWeight(1);
    }
}
