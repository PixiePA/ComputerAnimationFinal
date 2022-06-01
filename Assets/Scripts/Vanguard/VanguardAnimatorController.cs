using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanguardAnimatorController : ShooterController
{
    [SerializeField] Animator vanguardAnimator;
    [SerializeField] Animator vanguardFigurineAnimator;
    [SerializeField] CharacterShootIK vanguardShootIK;

    [SerializeField] float speed;
    [SerializeField] float animationSpeed = 1;

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
        if (vanguardAnimator.recorderMode != AnimatorRecorderMode.Offline)
        {
            vanguardAnimator.speed = animationSpeed;
        }
        else
        {
            vanguardAnimator.speed = Mathf.Max(0, animationSpeed);
        }
        if (vanguardAnimator.recorderMode == AnimatorRecorderMode.Playback)
        {
            if (vanguardAnimator.playbackTime == (vanguardAnimator.recorderStopTime - vanguardAnimator.recorderStartTime))
            {
                vanguardAnimator.StopPlayback();
            }
        }
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

    public void Dodge()
    {
        vanguardAnimator.SetTrigger("dodge");
    }

    public void SetDeathTrigger()
    {
        vanguardAnimator.ResetTrigger("resetDeath");
        vanguardAnimator.SetTrigger("isKilled");
    }

    public void SetRespawnTrigger()
    {
        vanguardAnimator.ResetTrigger("isKilled");
        vanguardAnimator.SetTrigger("resetDeath");
    }

    public void StartBracing()
    {
        vanguardAnimator.SetBool("isBracingAgainstCover", true);
    }

    public void StopBracing()
    {
        vanguardAnimator.SetBool("isBracingAgainstCover", false);
    }

    public void Kick()
    {
        vanguardAnimator.SetTrigger("kick");
    }

    public void StartRecordingMotion()
    {
        vanguardAnimator.StartRecording(1000);
        Debug.Log(vanguardAnimator.recorderMode);
    }

    public void StopRecordingMotion()
    {
        vanguardAnimator.StopRecording();
    }

    public void StartPlayback()
    {
        vanguardAnimator.StartPlayback();
    }

    public void StopPlayback()
    {
        vanguardAnimator.StopPlayback();
        vanguardAnimator.SetTrigger("fullReset");
    }

    public void ResetAllLayerOverrides()
    {
        vanguardAnimator.SetTrigger("fullReset");
    }
}
