using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used to detect a collision
//the 'is trigger' option must be checked in the gameobject collider for this to work

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "MyCube")
        {
            Destroy(other.gameObject);
            Debug.Log("Done");
        }
    }
}
