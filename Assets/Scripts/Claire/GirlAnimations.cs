using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GirlAnimations : MonoBehaviour
{
    private Animator anim;
    public static bool IsInFront;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        IsInFront = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInFront) //alternatively, could use IsInFront==true
        {
            if (Input.GetKeyDown(KeyCode.P)) //P for 'prize'
            {
                anim.SetTrigger("NowPoint");
                anim.SetTrigger("NowIdle");
                GameObject.Find("ClaireSpeech").GetComponent<Text>().text = "You've won a prize! Pick from anything on the table.";
                GameObject.Find("Background").GetComponent<Image>().enabled = true;
                StartCoroutine("WaitABit", 5);
            }
            if (Input.GetKeyDown(KeyCode.E)) //E for 'explain'
            {
                anim.SetTrigger("NowTalk");
                anim.SetTrigger("NowIdle");
                GameObject.Find("ClaireSpeech").GetComponent<Text>().text = "Welcome! Grab some coconuts and throw them at the target.";
                GameObject.Find("Background").GetComponent<Image>().enabled = true;
                StartCoroutine("WaitABit", 5);
            }
        }
    }

    private IEnumerator WaitABit(int waitTime) //this will turn off the notice 
    {
        yield return new WaitForSeconds(waitTime);
        GameObject.Find("ClaireSpeech").GetComponent<Text>().text = "";
        GameObject.Find("Background").GetComponent<Image>().enabled = false;
    }
}
