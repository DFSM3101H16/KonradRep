using UnityEngine;
using System.Collections;

public class kollisjonFysikk : MonoBehaviour {

    public float mass =1f;
    public Vector3 Vel = new Vector3 ();
    private Vector3 reference = new Vector3(1f, 0f, 0f);


	// Use this for initialization
	void Start () {
        transelation();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        setPosition();
        getColli();
	}

    void getColli()
    {
        RaycastHit bounce;
        if (Physics.Raycast(transform.position,Vel, out bounce, 0.5f))
        {
            if (bounce.collider == true)
            {
                //transelation();
                Vel.y = -Vel.y;
                print("bounce");
            }
           
        }
            
    }
    void setPosition()
    {
        transform.position += Vel * Time.deltaTime;
    }
   

    void transelation()
    {
        float theta = Vector3.Angle(Vel, reference);


        Vector3 velC = Vel *  Mathf.Cos(theta);
        Vector3 velS = -Vel * Mathf.Sin(theta);

        Debug.Log(theta);
        Debug.Log(velC.magnitude);
        Debug.Log(velS.magnitude);
        Debug.Log(Vel.magnitude);

    }
}
