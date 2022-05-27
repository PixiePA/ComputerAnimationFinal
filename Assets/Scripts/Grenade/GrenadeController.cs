using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float pulseRate;
    [SerializeField] float fuse;
    [SerializeField] GameObject explosion;
    [SerializeField] float explosionSize = 2;

    private float fuseTimer;
    // Start is called before the first frame update
    void Start()
    {
        fuseTimer = fuse;
    }

    // Update is called once per frame
    void Update()
    {
        if ((fuseTimer -= Time.deltaTime) <= 0)
        {
            GameObject spawnedExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
            foreach (Transform transform in spawnedExplosion.GetComponentsInChildren<Transform>())
            {
                transform.localScale = new Vector3(explosionSize, explosionSize, explosionSize);
            }
            Destroy(this.gameObject);
        }
        animator.SetFloat("pulseSpeed", pulseRate);
    }
}
