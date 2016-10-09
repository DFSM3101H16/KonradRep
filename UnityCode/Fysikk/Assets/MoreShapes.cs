using UnityEngine;
using System.Collections;

public class MoreShapes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.localScale = new Vector3(5, 0.1f, 5);
        }

        
	}
}
