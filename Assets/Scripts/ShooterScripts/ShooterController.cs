using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShooterController : MonoBehaviour
{
    [SerializeField] protected int shooterID;

    private void OnEnable()
    {
        GunEvents.onShootAtTarget += ShootAtTarget;
    }

    private void OnDisable()
    {
        GunEvents.onShootAtTarget -= ShootAtTarget;
    }

    abstract protected void ShootAtTarget(int shooterID, Transform target);

    protected void FindTarget(int targetID)
    {
        GunEvents.CallTarget(targetID, shooterID);
    }
}
