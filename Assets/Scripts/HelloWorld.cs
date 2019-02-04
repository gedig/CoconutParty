using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelloWorld : MonoBehaviour
{
<<<<<<< HEAD
   // public GameObject textbox;
=======
    // can be used to demo how to add a script as a component (in this case, to a Text gameobject), or to demo the UI 

>>>>>>> 80d8952fc598dec435bd98bcce1d85ce13b4d5d0
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
