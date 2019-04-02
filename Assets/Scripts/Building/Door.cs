using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class Door : MonoBehaviour
{
    private Animator openDoor;
    public static bool InFrontOfDoor;
    public AudioClip creakingdoor;
    private bool HasPlayedAudio;

    // Start is called before the first frame update
    void Start()
    {
        openDoor = transform.parent.transform.GetComponent<Animator>();
        HasPlayedAudio = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (InFrontOfDoor && FindPrizes.hasKey && HasPlayedAudio == false)
        {
            openDoor.Play("DoorOpen");
            GetComponent<AudioSource>().PlayOneShot(creakingdoor);
            HasPlayedAudio = true;
        }
    }
}
