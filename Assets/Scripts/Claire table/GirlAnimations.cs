using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GirlAnimations : MonoBehaviour
{
    private Animator anim;
    public static bool IsInFront;
    private Text clairsSpeech;
    private GameObject clairsBG;
    private bool HasVisited;
    private bool animDone;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        IsInFront = false;
        clairsSpeech = GameObject.Find("ClaireSpeech").GetComponent<Text>(); //can assign a gameobject component to a variable
        clairsBG = GameObject.Find("Background"); //can assign a gameobject to a variable
        HasVisited = false;
        animDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInFront & CoconutWin.haveWon == true && animDone == false)
        {
            anim.SetTrigger("NowPoint");
            anim.SetTrigger("NowIdle");
            clairsSpeech.text = "You've won a prize! Pick from anything on the table.";
            clairsBG.GetComponent<Image>().enabled = true;
            StartCoroutine("WaitABit", 5);
            animDone = true;
        }
        if (IsInFront & HasVisited == false)
        {
            anim.SetTrigger("NowTalk");
            anim.SetTrigger("NowIdle");
            GameObject.Find("ClaireSpeech").GetComponent<Text>().text = "Welcome! Grab some coconuts and throw them at the target.";
            GameObject.Find("Background").GetComponent<Image>().enabled = true;
            StartCoroutine("WaitABit", 5);
            HasVisited = true;
        }
    }

    private IEnumerator WaitABit(int waitTime) //this will turn off the notice 
    {
        yield return new WaitForSeconds(waitTime);
        clairsSpeech.text = "";        
        clairsBG.GetComponent<Image>().enabled = false;
    }
}
