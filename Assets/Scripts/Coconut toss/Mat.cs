using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mat : MonoBehaviour
{
    public Transform crosshairs;

    private void OnTriggerEnter()
    {
        GameObject.Find("Launcher").SendMessage("OnMat", true);
        crosshairs.GetComponent<Image>().enabled = true;
    }

    private void OnTriggerExit()
    {
        GameObject.Find("Launcher").SendMessage("OnMat", false);
        crosshairs.GetComponent<Image>().enabled = false;
    }
}
