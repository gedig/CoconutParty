using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFireOnClick : MonoBehaviour
{
    public GameObject projectile;
    public float ProjectileForce = 250.0f;

    void Update()
    {
        // Alternatively, show Input.GetMouseButton
        if (Input.GetMouseButtonDown(0)) {
            Vector3 projSpawnOffset = (transform.forward * 1.0f) + (transform.right * 1.0f);
            GameObject proj = Instantiate<GameObject>(projectile, transform.position + projSpawnOffset,
                Quaternion.identity);
            proj.GetComponent<Rigidbody>().AddForce(transform.forward * ProjectileForce);
        }
    }
}
