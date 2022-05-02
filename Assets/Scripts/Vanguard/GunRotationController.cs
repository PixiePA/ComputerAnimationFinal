using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotationController : MonoBehaviour
{
    public Transform Target;
    [SerializeField] float yRotationCorrection;
    [SerializeField] float xRotationCorrection;


    Quaternion BaseRotation;
    Quaternion targetRotation;

    [SerializeField] Animator vanguardAnimator;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!vanguardAnimator)
        {
            vanguardAnimator = GetComponent<Animator>();
        }

        BaseRotation = transform.localRotation;
        targetRotation = BaseRotation;

    }

    // Update is called once per frame
    void Update()
    {
        if (Target)
        {
            transform.LookAt(Target);
            transform.Rotate(Vector3.up, yRotationCorrection);
            transform.Rotate(Vector3.left, xRotationCorrection);

            targetRotation = transform.localRotation;
        }
        transform.localRotation = Quaternion.Lerp(BaseRotation, targetRotation, vanguardAnimator.GetFloat("ikShoot")/2);




    }

}
