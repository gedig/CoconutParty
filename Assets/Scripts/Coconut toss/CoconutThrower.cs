using UnityEngine;
using System.Collections;
[RequireComponent (typeof(AudioSource))]

public class CoconutThrower : MonoBehaviour {

    public AudioClip throwSound;
    public GameObject coconutPrefab;
    public static bool canThrow = false;
    public float ProjectileForce;
    public int MaxCoconuts;
    private int CoconutCount;
    private bool _onmat = false;

    public void OnMat (bool onmat)
    {
        _onmat = onmat;
        CoconutCount = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _onmat && CoconutCount < MaxCoconuts && FindCoconuts.foundCoconuts)
        {
          //  Vector3 projSpawnOffset = (transform.right * 0.3f ) + (transform.up * 0.1f) + (transform.forward * -0.1f);
            GameObject proj = Instantiate<GameObject>(coconutPrefab, transform.position, Quaternion.identity);

            proj.name = "coconutThrow";
            proj.GetComponent<Rigidbody>().AddForce(transform.forward * ProjectileForce);
            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), proj.GetComponent<Collider>(), true);
            GetComponent<AudioSource>().PlayOneShot(throwSound);
            CoconutCount++;
        }
    }
}
