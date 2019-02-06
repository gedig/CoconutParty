using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class ManagedFireOnClick : MonoBehaviour
{
    public int MaxProjectiles = 80;
    public GameObject Projectile;
    public float ProjectileForce = 250.0f;

    private GameObject[] _projectilePool;
    private int _poolIndex = 0;

    void Start()
    {
        _projectilePool = new GameObject[MaxProjectiles];
    }

    void Update()
    {
        // Alternatively, show Input.GetMouseButton
        if (Input.GetMouseButtonDown(0)) {
            Vector3 projSpawnOffset = (transform.forward * 1.0f) + (transform.right * 1.0f);
            GameObject proj = getNewProjectileFromPool();
            proj.transform.position = transform.position + projSpawnOffset;
            proj.SetActive(true); // Could be inactive when coming from the pool
            proj.GetComponent<Rigidbody>().AddForce(transform.forward * ProjectileForce);
        }
    }

    private GameObject getNewProjectileFromPool()
    {
        GameObject projectileToReturn = _projectilePool[_poolIndex];
        if (projectileToReturn == null) {
            // We haven't created a prefab for this slot yet. Create & Assign it
            projectileToReturn = Instantiate<GameObject>(Projectile);
            _projectilePool[_poolIndex] = projectileToReturn;
        } else {
            projectileToReturn.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        _poolIndex++;

        if (_poolIndex >= _projectilePool.Length) {
            _poolIndex = 0;
        }

        return projectileToReturn;
    }
}
