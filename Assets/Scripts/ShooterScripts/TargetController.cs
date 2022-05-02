using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] int targetID;

    private void OnEnable()
    {
        GunEvents.onCallTarget += DeclareTarget;
    }

    private void OnDisable()
    {
        GunEvents.onCallTarget -= DeclareTarget;
    }

    private void DeclareTarget(int targetID, int shooterID)
    {
        
        if (this.targetID == targetID)
        {
            GunEvents.ShootAtTarget(shooterID, gameObject.transform);
        }
    }
}
