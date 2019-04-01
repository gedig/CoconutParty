using UnityEngine;
using System.Collections;
[RequireComponent (typeof(AudioSource))]

public class CoconutThrower : MonoBehaviour {

    public delegate void CoconutAction(int coconuts);
    public static event CoconutAction CoconutUpdate;

    public AudioClip throwSound;
    public GameObject coconutPrefab;
    public static bool canThrow = false;
    public float ProjectileForce;
    public int MaxCoconuts;
    private int _coconutCount;
    private bool _onmat = false;

    public void OnMat (bool onmat)
    {
        _onmat = onmat;
    }

    private void AddCoconut()
    {
        _coconutCount++;
        CoconutUpdate(_coconutCount);
    }

    void Start()
    {
        FindCoconuts.CoconutAcquired += AddCoconut;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !InteractionWithFood.AtFood && !PermitTalking.AtTable && _coconutCount > 0 && !PauseMenu._paused)
        {
            GameObject proj = Instantiate<GameObject>(coconutPrefab, transform.position, Quaternion.identity);
            proj.name = "coconutThrow";
            proj.GetComponent<Rigidbody>().AddForce(transform.forward * ProjectileForce);
            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), proj.GetComponent<Collider>(), true);
            GetComponent<AudioSource>().PlayOneShot(throwSound);
            _coconutCount--;
            CoconutUpdate(_coconutCount);
        }
    }
}
