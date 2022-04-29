using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class VanguardEvents
{
    static public Action<int> onGunFired;
    static public void GunFired(int id)
    {
        if (onGunFired != null)
        {
            onGunFired(id);
        }
    }
}
