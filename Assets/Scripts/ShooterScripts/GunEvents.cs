using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GunEvents
{
    public static Action<int, int> onCallTarget;
    public static void CallTarget(int targetID, int shooterID)
    {
        if (onCallTarget != null)
        {
            onCallTarget(targetID, shooterID);
        }
    }

    public static Action<int, Transform> onIdentifyTarget;
    public static void IdentifyTarget(int shooterID, Transform target)
    {
        if (onIdentifyTarget != null)
        {
            onIdentifyTarget(shooterID, target);
        }
    }
}
