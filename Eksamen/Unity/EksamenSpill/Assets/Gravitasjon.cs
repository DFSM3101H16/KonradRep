using UnityEngine;
using System.Collections;

public class Gravitasjon : MonoBehaviour {
    public Vector3 tyngdekraft= new Vector3 (0,9.81f,0);

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate()
    {
        this.transform.position += tyngdekraft * Time.deltaTime + 0.5f * tyngdekraft * Time.deltaTime*Time.deltaTime;
    }

}
