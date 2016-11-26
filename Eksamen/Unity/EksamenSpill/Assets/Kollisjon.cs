using UnityEngine;
using System.Collections;

public class Kollisjon : MonoBehaviour {

    public Vector3 getKollisjon(Vector3 fart)
    {
        RaycastHit kollisjon;
        if(Physics.Raycast(transform.position, fart, out kollisjon, 0.5f))
        {
            if(kollisjon.collider == true)
            {
                float thetaVinkel = Vector3.Angle(kollisjon.normal, fart);
                fart = fart * -2;
                //legge til matte. 
                //fart = Quaternion.AngleAxis(thetaVinkel, kollisjon.normal) * fart;
                return fart;
            }
            return fart;
        }
        return fart;
    }
}
