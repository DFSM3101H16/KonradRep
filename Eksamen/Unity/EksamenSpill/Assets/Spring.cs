using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour {
    private float koeffisient = 0.9f;
    private float lengde = 2f; 

    public Vector3 komprimert(Vector3 fart, float mass)
    {
        float potensiellEnergi = lengde*koeffisient;
        fart = fart + fart.normalized * potensiellEnergi / mass;
        return fart;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
