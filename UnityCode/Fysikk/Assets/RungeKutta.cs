using UnityEngine;
using System.Collections;

public class RungeKutta : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public static Vector3[] rungeKutta(Vector3 vel, Vector3 pos,Vector3 G, float drag, float density, float area, float mass, float h)
    {
        Vector3 s1 = pos;
        Vector3 v1 = vel;
        Vector3 a1 = function(vel, drag, density, area, mass, h);

        Vector3 s2 = pos + v1 * h * 0.5f;
        Vector3 v2 = vel + a1 * h * 0.5f;
        Vector3 a2 = function(v2, drag, density, area, mass, h / 2f);

        Vector3 s3 = pos + v2 * h * 0.5f;
        Vector3 v3 = vel + a2 * h * 0.5f;
        Vector3 a3 = function(v3, drag, density, area, mass, h / 2f);

        Vector3 s4 = pos + v3 * h;
        Vector3 v4 = vel + a3 * h;
        Vector3 a4 = function(v4, drag, density, area, mass, h);

        pos += h / 6 * (s1 + (s2 * 2) + (s3 * 2) + s4);
        vel += h / 6 * (v1 + (v2 * 2) + (v3 * 2) + v4);
        Vector3 af = h / 6 * (a1 + (a2 * 2) + (a3 * 2) + a4);

        return new Vector3[] { vel, af };
    }

public static Vector3 function(Vector3 veelo,float dragf,float densityf,float areaf,float massf, float timef)
{
    
    return  veelo;
    }

    /*
    private static Vector3 function( Vector3 vel,  float drag, float density, float area,float mass,float h)
    {
        Vector3 y;

        
        float Fdrag = density * vel.magnitude * vel.magnitude * drag * area;

        if (vel.x != 0)
        {
            float dragX = (vel.x / vel.magnitude) * (-Fdrag);
            float Fx = dragX + vel.x * mass;
        }

        if (vel.y != 0)
        {
            float dragY = (vel.y / vel.magnitude) * (-Fdrag);
            float Fy = dragY + vel.y * mass;
        }

        if (vel.z != 0)
        {
            float dragZ = (vel.z / vel.magnitude) * (-Fdrag);
            float Fz = dragZ + vel.z * mass;
        }
        /*
        float aclX = acl.x + (-Fdrag) * vel.x / (mass * vel.magnitude);
        float aclY = acl.y + (-Fdrag) * vel.y / (mass * vel.magnitude);
        float aclZ = acl.z + (-Fdrag) * vel.z / (mass * vel.magnitude);
        
        float mg = mass * acl.y;
        if (mg > Fdrag)
        {
            vel += acl * Time.deltaTime;
        }
        else if(mg == Fdrag) 
        {
            return acl;
        }
        else
        {
            vel -= acl * Time.deltaTime;
        }
        y = acl;
       
        return y;
    } 
}*/

}