using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanguardAnimatorController : ShooterController
{
    [SerializeField] Animator vanguardAnimator;
    [SerializeField] Animator vanguardFigurineAnimator;
    [SerializeField] CharacterShootIK vanguardShootIK;

    [SerializeField] float speed;
    bool isGunReady;
    public bool IsGunReady
    {
        get => isGunReady;
        set
        {
            isGunReady = value;
            vanguardAnimator.SetBool("bIsRifleReady", isGunReady);
        }
    }

    bool isCrouched;
    public bool IsCrouched
    {
        get => isCrouched;
        set
        {
            isCrouched = value;
            vanguardAnimator.SetBool("bIsCrouching", isCrouched);
        }
    }

    private void Update()
    {
        vanguardAnimator.SetFloat("speed", speed);    
    }

    // Start is called before the first frame update
    private void Awake()
    {

        if (!vanguardFigurineAnimator) vanguardFigurineAnimator = GetComponent<Animator>();
        if (!vanguardAnimator) vanguardAnimator = GetComponentInChildren<Animator>();
        if (!vanguardShootIK) vanguardShootIK = GetComponentInChildren<CharacterShootIK>();
    }

    protected override void AimAtTarget(int shooterID, Transform target)
    {
        if (this.shooterID == shooterID)
        {
            vanguardShootIK.AimTarget = target;
        }
    }

    public void SetGunIsReady()
    {
        IsGunReady = true;

    }

    public void SetGunIsDown()
    {
        IsGunReady = false;
    }

    public void FireGun(int targetID)
    {
        FindTarget(targetID);
        vanguardAnimator.SetTrigger("shootRifle");
    }

    public void AimGun(int targetID)
    {
        FindTarget(targetID);
    }

    public void StartCrouch()
    {
        IsCrouched = true;
    }

    public void StopCrouch()
    {
        IsCrouched = false;
    }
}
