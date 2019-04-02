using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTray : MonoBehaviour
{
    private float y;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        y += Time.deltaTime * speed;
        transform.rotation = Quaternion.Euler(0, y, 0);
    }
}
