using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Door.InFrontOfDoor = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Door.InFrontOfDoor = false;
    }
}
