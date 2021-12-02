using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionLaunch : MonoBehaviour
{
    public GameObject boom;
    public float radius, boomForce;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(boom, transform.position, transform.rotation);
        Destroy(boom, 3);
        knockback();
        Destroy(gameObject);
    }

    void knockback()
    {
        Collider[] colliders = Physics.OverlapSphere (transform.position, radius);

        foreach (Collider nearby in colliders)
        {
            Rigidbody rigg = nearby.GetComponent<Rigidbody>();
            if(rigg != null)
            {
                rigg.AddExplosionForce(boomForce, transform.position, radius);
            }
        }
    }
}
