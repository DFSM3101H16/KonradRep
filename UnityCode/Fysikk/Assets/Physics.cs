using UnityEngine;
using System.Collections;

public class Physics : MonoBehaviour {
    public float Mass;
    
    public Vector3 Velocity = new Vector3(0, 5, 10);

    private Vector3 GravityEarth = new Vector3(0, -9.81f, 0);
    private Vector3 KineticEnergy = new Vector3(0,0,0);
    private float PotentialEnergy;
    private Vector3 Gravity = new Vector3();

    bool on = true;

    // Use this for initialization
    void Start() {

        Gravity = GravityEarth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            setPosition();
            setVelocity();
        }
    }
    
    void setPosition()
    {
        transform.position +=   Velocity * Time.deltaTime + 0.5f * Gravity * Time.deltaTime*Time.deltaTime;
        
    }

    void setVelocity()
    {
        Velocity = Velocity + Gravity * Time.deltaTime;

    }

    void OnTriggerEnter(Collider other)
    {
        on = false;
    }

    /*
    void setAirDrag()
    {

    }
    
    void setPEnergy()
    {
        
        PotentialEnergy = -Mass * Position.y;
    }
    
    void setKEnergy()
    {
        KineticEnergy = Mass * Velocity;
    }
    */
}
