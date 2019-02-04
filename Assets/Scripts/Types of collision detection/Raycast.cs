using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    //used to detect an object before a collision

    RaycastHit hit;
    public int distance;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast (transform.position, transform.forward, out hit, distance))
        {
            if (hit.collider.gameObject.name == "MyCube")
            {
                Destroy(hit.collider.gameObject);
                Debug.Log("Done");
            }
        }
    }    
}
