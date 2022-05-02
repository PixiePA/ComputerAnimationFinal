using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShooterController : MonoBehaviour
{
    [SerializeField] protected int shooterID;

    private void OnEnable()
    {
        GunEvents.onIdentifyTarget += AimAtTarget;
    }

    private void OnDisable()
    {
        GunEvents.onIdentifyTarget -= AimAtTarget;
    }

    abstract protected void AimAtTarget(int shooterID, Transform target);

    protected void FindTarget(int targetID)
    {
        GunEvents.CallTarget(targetID, shooterID);
    }
}
