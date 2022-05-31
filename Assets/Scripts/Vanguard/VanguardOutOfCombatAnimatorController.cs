using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanguardOutOfCombatAnimatorController : MonoBehaviour
{
    public float speed;
    public Animator vanguardAnimator;
    public GrabAnimatiionIKController grabIKController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vanguardAnimator.SetFloat("speed", speed);
    }

    void GrabObject(int id)
    {
        grabIKController.GrabObject(id);
    }

    void LookAround()
    {
        vanguardAnimator.SetTrigger("look");
    }
}
