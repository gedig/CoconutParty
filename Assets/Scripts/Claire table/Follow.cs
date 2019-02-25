using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        //Vector3 is needed to prevent the gameobject from tilting as it follows the target at close range  
        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);           
        transform.LookAt(targetPosition);
    }
}
