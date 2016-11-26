using UnityEngine;
using System.Collections;

public class flipperLeft : MonoBehaviour
{
    private bool flipping = false;
    private bool flippingB = false;
    private float flipperVinkel = 0f;
    private float flipperHastighet = 200f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        flipper();
    }
    void flipper()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && flipperVinkel > -45f)
        {
            flipperVinkel += -flipperHastighet * Time.deltaTime;
            transform.parent.localRotation =
                Quaternion.Euler(0f, flipperVinkel, 0f);

            // antall grader med hastighet.
            flipping = true;
            flippingB = false;

        }
        else if (!Input.GetKey(KeyCode.LeftArrow) && flipperVinkel < 45f)
        {
            flipperVinkel += flipperHastighet * Time.deltaTime;
            transform.parent.localRotation =
                Quaternion.Euler(0f, flipperVinkel, 0f);
            flipping = false;
            flippingB = true;
        }
        else
        {
            flippingB = false;
            flipping = false;
        }

    }
    public Vector3 flipperTreff(Vector3 fart, Vector3 treffPunkt)
    {
        if (flipping)
        {
            float distance = Vector3.Distance(treffPunkt, transform.parent.position);
            fart = fart.normalized * distance * flipperHastighet * Time.deltaTime;
        }
        else if (flippingB)
        {
            float distance = Vector3.Distance(treffPunkt, transform.parent.position);
            fart = fart.normalized * distance * flipperHastighet * Time.deltaTime;
        }
        return fart;
    }
}
