using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    //used to detect a collision
    //the 'is trigger' option in the gameobject collider must be unchecked for this to work

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.name == "MyCube")   
        {
            Destroy(hit.gameObject);
            Debug.Log("Done");
        }
    }
}
