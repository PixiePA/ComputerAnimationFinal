using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotationController : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] float yRotationCorrection;
    [SerializeField] float xRotationCorrection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target);
        transform.Rotate(Vector3.up, yRotationCorrection);
        transform.Rotate(Vector3.left, xRotationCorrection);
    }
}
