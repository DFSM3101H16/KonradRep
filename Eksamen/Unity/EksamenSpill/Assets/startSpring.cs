using UnityEngine;
using System.Collections;

public class startSpring : MonoBehaviour {

    public Vector3 release (Vector3 fart)
    {   
        if (Input.GetKey(KeyCode.Space))
        {
            fart = fart * 3f;
        }
        return fart;
    }
	// Use this for initializ1ation
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
