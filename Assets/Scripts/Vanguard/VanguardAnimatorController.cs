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
            SetGunReadyFlag();
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

    protected override void ShootAtTarget(int shooterID, Transform target)
    {
        if (this.shooterID == shooterID)
        {
            vanguardShootIK.AimTarget = target;
            vanguardAnimator.SetTrigger("shootRifle");
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
    }


    private void SetGunReadyFlag()
    {
        vanguardAnimator.SetBool("bIsRifleReady", IsGunReady);
    }
}
