using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotationController : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] float yRotationCorrection;
    [SerializeField] float xRotationCorrection;

    [SerializeField] Animator vanguardAnimator;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!vanguardAnimator)
        {
            vanguardAnimator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (vanguardAnimator.GetFloat("ikShoot") > 0.8f)
        {
            Quaternion currentRotation = transform.rotation;
            transform.LookAt(Target);
            Quaternion targetRotation = transform.rotation;
            transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, vanguardAnimator.GetFloat("ikShoot"));

            transform.Rotate(Vector3.up, yRotationCorrection);
            transform.Rotate(Vector3.left, xRotationCorrection);
        }
    }
}
