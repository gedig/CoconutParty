using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class CoconutWin : MonoBehaviour {

    public static int targets = 0;
    public static bool haveWon = false;
    public AudioClip winSound;

	// Update is called once per frame
	void Update () {
        if (targets == 3 && haveWon == false)
        {
            targets = 0;
            Debug.Log("I win");
            GetComponent<AudioSource>().PlayOneShot(winSound);
            haveWon = true;
        }
	}
}
