using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootController : ShooterController
{
    [SerializeField] EnemyGunController enemyGunController;
    [SerializeField] Animator EnemyAnimator;

    public float speed;

    // Start is called before the first frame update

    protected override void AimAtTarget(int shooterID, Transform target)
    {
        if (this.shooterID == shooterID)
        {
            enemyGunController.SetTarget(target);
            EnemyAnimator.SetTrigger("shoot");
        }
    }

    public void FireGun(int targetID)
    {
        FindTarget(targetID);
    }

    private void Update()
    {
        EnemyAnimator.SetFloat("speed", speed);
    }

    public void FallingDeath()
    {
        EnemyAnimator.SetTrigger("fallingDeath");
    }

    public void FlyingDeath()
    {
        EnemyAnimator.SetTrigger("flyingDeath");
    }
}
