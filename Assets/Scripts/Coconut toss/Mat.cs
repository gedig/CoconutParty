using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mat : MonoBehaviour
{
    public Transform crosshairs;
    public bool toggleCrosshair = false;

    private void OnTriggerEnter()
    {
        GameObject.Find("Launcher").SendMessage("OnMat", true);
        if (toggleCrosshair) {
            crosshairs.GetComponent<Image>().enabled = true;
        }
    }

    private void OnTriggerExit()
    {
        GameObject.Find("Launcher").SendMessage("OnMat", false);
        if (toggleCrosshair) {
            crosshairs.GetComponent<Image>().enabled = false;
        }
    }
}
