using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelloWorld : MonoBehaviour
{
   // public GameObject textbox;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Hello");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Hello()
    {
        yield return new WaitForSeconds(5);
        GetComponent<Text>().text = "HELLO WORLD!";
    }
}
