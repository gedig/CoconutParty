using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GirlAnimations : MonoBehaviour
{
    [SerializeField] private Text _clairsSpeech;
    [SerializeField] private Image _clairsBG;

    private Animator anim;
    public static bool IsInFront;
    private bool HasVisited;
    private bool animDone;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        IsInFront = false;
        if (_clairsSpeech == null) {
            _clairsSpeech = GameObject.Find("ClaireSpeech").GetComponent<Text>(); //can assign a gameobject component to a variable
        }
        if (_clairsBG == null) {
            _clairsBG = GameObject.Find("Background").GetComponent<Image>(); //can assign a gameobject to a variable
        }
        
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
            _clairsSpeech.text = "You've won a prize! Pick from anything on the table.";
            _clairsBG.enabled = true;
            StartCoroutine("WaitABit", 5);
            animDone = true;
        }
        if (IsInFront & HasVisited == false)
        {
            anim.SetTrigger("NowTalk");
            anim.SetTrigger("NowIdle");
            _clairsSpeech.text = "Welcome! Grab some coconuts and throw them at the target.";
            _clairsBG.enabled = true;
            StartCoroutine("WaitABit", 5);
            HasVisited = true;
        }
    }

    private IEnumerator WaitABit(int waitTime) //this will turn off the notice 
    {
        yield return new WaitForSeconds(waitTime);
        _clairsSpeech.text = "";        
        _clairsBG.enabled = false;
    }
}
