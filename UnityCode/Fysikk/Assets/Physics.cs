using UnityEngine;
using System.Collections;


public class cusPhysics : MonoBehaviour {
    public float Mass;
    public float CoefficientDrag;   //based on the shape of the object
    public Vector3 Velocity = new Vector3(0, 0, 0);     //start velocity

    

    private Vector3 GravityEarth = new Vector3(0, -9.81f, 0); //earths gravity.
    private float airDensity;       //density in the air on earth based on height.

    public float radius;
    private float Area;

    private Vector3 Gravity = new Vector3();
    
    private bool on = true;
    private float pi = 3.14159265359f;


    public Vector3 x = new Vector3(0f, 0f, 0f);
    public Vector3 y = new Vector3(0f, 0f, 0f);
    
    // Use this for initialization
    void Start() {
        Area = 4f * pi * radius * radius;
        Gravity = GravityEarth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Time.deltaTime;
        if (on)
        {
            //setPosition();
            setDensity(transform.position.y);
            //setVelocity();
            setVelocity2();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            setArea();
            setDrag();
        }

    }
    
    /*void setPosition()
    {
        transform.position +=   Velocity * Time.deltaTime + 0.5f * Gravity * Time.deltaTime*Time.deltaTime;
        
    }

    void setVelocity()
    {
        
        Velocity = Velocity + Gravity * Time.deltaTime;//+ dragForce;

    }
    */

    void setDensity(float posY)
    {
        if(posY < 305)
        {
            airDensity = 1.225f;
        }
        else if(posY < 610)
        {
            airDensity = 1.189f;
        }
        else if(posY < 914)
        {
            airDensity = 1.154f;
        }
        else if(posY < 1219)
        {
            airDensity = 1.121f;
        }
        else if(posY < 1524)
        {
            airDensity = 1.088f;
        }
        else if(posY < 2134)
        {
            airDensity = 1.055f;
        }
        else if( posY < 3048)
        {
            airDensity = 0.992f;
        }
        else
        {
            airDensity = 0.905f;
        }
    }

    void OnTriggerEnter(Collider other)
    {   Debug.Log(Velocity);
        Debug.Log(Time.time);
        Velocity = Velocity*0;
        on = false;
        if(Velocity.magnitude< 16)
        {
            Debug.Log("you win");
        }    
    }

    void setDrag()
    {
        CoefficientDrag = 1.4f;
    }

    void setArea()
        {
        Area = 20f;
    }

    void setVelocity2()
        {
        Vector3[] Temp = new Vector3[] { x, y };

        Temp =  RungeKutta.rungeKutta(Velocity, transform.position, Gravity, CoefficientDrag, airDensity,Area, Mass, Time.deltaTime);
        Velocity += Temp[1]*Time.deltaTime;
        transform.position += Temp[0]*Time.deltaTime;
    }

}
