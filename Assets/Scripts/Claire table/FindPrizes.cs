using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPrizes : MonoBehaviour
{
    RaycastHit hit;
    public float distance;
    public static bool hasKey;
    private bool collectedPrize;
    private int layerMask;

    // Start is called before the first frame update
    void Start()
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
            else if (collectedPrize == true)
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, distance, layerMask))
                {
                    if (hit.collider.gameObject.name == "Food")
                    {
                    Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}
