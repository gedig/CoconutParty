using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeColourLive : MonoBehaviour
{
    public int ThisNumber;
    private int _thisNumber;

    private Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Projectile")
        {
            // Randomize The colour:
            RandomizeColour();
        }
    }

    /**
     * This does Raycasting Logic for us. OnMouseDown is called when the user is looking at this
     * object's collider and clicks their main mouse button.
     */
    void OnMouseDown()
    {
        RandomizeColour();
    }

    public void RandomizeColour()
    {
        float r = Random.Range(0f,1f);
        float g = Random.Range(0f,1f);
        float b = Random.Range(0.0f,1f);
        Color newColour = new Color(r, g, b);
        _renderer.material.color = newColour;
    }
}
