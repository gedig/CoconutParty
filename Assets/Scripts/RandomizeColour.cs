using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeColour : MonoBehaviour
{
    public void ChangeColour() {
        GetComponent<Renderer>().material.color = new Color(Random.Range(0f,1f),Random.Range(0f,1f), Random.Range(0f,1f));
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "Projectile")
        {
            ChangeColour();
        }
    }
}
