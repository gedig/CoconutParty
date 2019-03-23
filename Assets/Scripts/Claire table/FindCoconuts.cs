using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCoconuts : MonoBehaviour
{
    public delegate void CoconutAction();
    public static event CoconutAction CoconutAcquired;

    //used to detect an object before a collision

    RaycastHit hit;
    public float distance;
    public static bool hasKey;
    private bool collectedPrize;
    private int layerMask;

    private void Start()
    {
        collectedPrize = false;
        hasKey = false;
        layerMask = 1 << 9;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position - (transform.forward * -0.3f), transform.forward, out hit, distance, layerMask))
            {
                if (hit.collider.gameObject.name == "Coconut")
                {
                    hit.collider.gameObject.SetActive(false);
                    // Send message that a coconut was collected
                    CoconutAcquired();
                }
            }
            if (collectedPrize == false && CoconutWin.haveWon)
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, distance, layerMask))
                {
                    if (hit.collider.gameObject.name == "jeep" || hit.collider.gameObject.name == "Triceratops") 
                    {
                        Destroy(hit.collider.gameObject);
                        collectedPrize = true;
                    }
                    else if (hit.collider.gameObject.name == "Key")
                    {
                        Destroy(hit.collider.gameObject);
                        collectedPrize = true;
                        hasKey = true;
                    }
                }
            }
        }
    }
}
