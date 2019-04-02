using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionWithFood : MonoBehaviour
{
    public Transform crosshairs;
    public static bool AtFood = false;

    private void OnTriggerEnter()
    {
        crosshairs.GetComponent<Image>().enabled = true;
        AtFood = true;
    }

    private void OnTriggerExit()
    {
        crosshairs.GetComponent<Image>().enabled = false;
        AtFood = false;
    }
}
