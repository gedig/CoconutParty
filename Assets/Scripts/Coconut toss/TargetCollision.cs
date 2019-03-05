using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class TargetCollision : MonoBehaviour {

    private bool beenHit = false;
    private Animator targetRoot;
    public AudioClip hitSound;
    public float resetTime;

	// Use this for initialization
	void Start () {
        targetRoot = transform.parent.transform.parent.GetComponent<Animator>();	
	}

    private void OnCollisionEnter(Collision theObject)
    {
        if (beenHit == false && theObject.gameObject.name == "coconutThrow")
        {
            StartCoroutine("TargetHit");
        }
    }

    IEnumerator TargetHit()
    {
        GetComponent<AudioSource>().PlayOneShot(hitSound);
        targetRoot.Play("TargetDown");
        beenHit = true;
        CoconutWin.targets++;
        yield return new WaitForSeconds(resetTime);
        targetRoot.Play("TargetUp");
        beenHit = false;
        CoconutWin.targets--;
    }
}
