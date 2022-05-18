using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : MonoBehaviour
{
    [SerializeField] GameObject LaserToFire;
    [SerializeField] Transform BarrelTransform;
    //Vector3 BarrelPosition;
    bool FireTriggered;

    public float speed; 

    Transform targetTransform;

    public void FireGun()
    {
        FireTriggered = true;
    }

    private void Update()
    {
        //BarrelPosition = BarrelTransform.position;

        if (FireTriggered)
        {
            Instantiate(LaserToFire, BarrelTransform.position, Quaternion.identity).transform.LookAt(targetTransform);

            FireTriggered = false;
        }
    }

    public void SetTarget(Transform targetTransform)
    {
        this.targetTransform = targetTransform;
    }
}
