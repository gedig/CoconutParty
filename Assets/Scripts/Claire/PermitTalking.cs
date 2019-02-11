using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermitTalking : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        GirlAnimations.IsInFront = true;
    }

    private void OnTriggerExit()
    {
        GirlAnimations.IsInFront = false;
    }
}
