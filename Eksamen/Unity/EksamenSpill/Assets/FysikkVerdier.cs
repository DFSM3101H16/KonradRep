using UnityEngine;
using System.Collections;

public class FysikkVerdier : MonoBehaviour {
    Kollisjon sprett = new Kollisjon();
    public float mass = 0.5f;
    public Vector3 fart = new Vector3(0,0,10);
   private Vector3 tyngdekraft = new Vector3(0, 0, 2f); // 11 graders helling
    public float vinkelFart = 0f;
    public float coefficient = 0.05f;
    void Start()
    {

    }
    void FixedUpdate()
    {
        fart = getKollisjon();
        setPosisjon();
        setFart();
        setRotasjon();
       

    }

    public void setFart()
    {   //ish
        fart += tyngdekraft*Time.deltaTime;
        fart.y = 0f;
    }

    public void setPosisjon()
    {   
        //ish
        this.transform.position += fart * Time.deltaTime + 0.5f * tyngdekraft * Time.deltaTime * Time.deltaTime;
    }

    void setRotasjon()
    {
        this.transform.Rotate(Vector3.right * Time.deltaTime * vinkelFart); 
    }

    public Vector3 getKollisjon()
    {
        RaycastHit kollisjon;

        //if(Physics.SphereCast(transform.position, 0.3f,fart, out kollisjon,0.6f))
        if (Physics.Raycast(transform.position, fart, out kollisjon, 0.6f))
        {
            
            if (kollisjon.collider == true && Vector3.Distance(kollisjon.point, transform.position) < 0.5f) 
            {   
                //Physics.Raycast(transform.position, fart, out kollisjon, 0.5f);
                fart = fart - (2f * Vector3.Dot(fart, kollisjon.normal) * kollisjon.normal);
                fart = friksjon(fart, kollisjon.normal);
                if (kollisjon.transform.gameObject.tag == "flipperR")
                {
                    fart = kollisjon.transform.gameObject.GetComponent<Flipper>().flipperTreff(fart, kollisjon.point);
                }
                else if (kollisjon.transform.gameObject.tag == "flipperL")
                {
                    fart = kollisjon.transform.gameObject.GetComponent<flipperLeft>().flipperTreff(fart, kollisjon.point);
                }
                else if (kollisjon.transform.gameObject.tag == "spring")
                {
                    fart = kollisjon.transform.gameObject.GetComponent<Spring>().komprimert(fart, mass);
                }else if (kollisjon.transform.gameObject.tag == "startSpring")
                {
                    fart = kollisjon.transform.gameObject.GetComponent<startSpring>().release(fart);
                }
            }
                
            
            
        }
        return fart;
    }

    public Vector3 friksjon(Vector3 fart, Vector3 normal)
    {
        /* 
         float theta = Vector3.Angle(fart, normal);
         if (theta != 0)
         {
             float fartRetning = fart.magnitude * Mathf.Sin(theta);
             float friksjonNormalImpuls = 0.6f * (fart.magnitude * Mathf.Cos(theta));
            
             //0,5 stål mot tre
             // 0,002 rulling ? 
             // fart = fart - Koeffisient * vinkel  * kraft/fart.? 
             fart = fart.normalized * ((fartRetning - friksjonNormalImpuls) / Mathf.Sin(theta));
         }
         else
         {
             fart = fart * 0.9f;
         }*/
        fart = fart * 0.9f;
        return fart;
    }
}
