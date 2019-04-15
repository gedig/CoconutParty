using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeColourRaycast : MonoBehaviour
{

    /**
     * Note: This check isn't needed if you use the OnMouseDown method in RandomizeColourLive.cs
     *  This is 2 different ways to do the same thing. (And the OnMouseDown call is likely much more efficient.)
     */
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward, out hit, 100f);
            RandomizeColourLive colourScript = hit.collider.gameObject.GetComponent<RandomizeColourLive>();
            if (colourScript != null)
            {
                colourScript.RandomizeColour();
            }
        }
    }

}
