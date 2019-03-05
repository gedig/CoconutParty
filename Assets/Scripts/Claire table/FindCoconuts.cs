using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCoconuts : MonoBehaviour
{
    //used to detect an object before a collision

    RaycastHit hit;
    public float distance;
    public static bool foundCoconuts;
    public static bool hasKey;
    private bool collectedPrize;

    private void Start()
    {
        foundCoconuts = false;
        collectedPrize = false;
        hasKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            {
            if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
            {
                if (hit.collider.gameObject.name == "Coconut")
                {
                    Destroy(hit.collider.gameObject);
                    foundCoconuts = true;
                }
            }
            if (collectedPrize == false && CoconutWin.haveWon)
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
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
