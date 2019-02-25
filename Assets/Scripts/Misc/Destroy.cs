using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "coconutThrow")
        {
            StartCoroutine("KillMe");
        } 
    }

    private IEnumerator KillMe()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    } 
}
