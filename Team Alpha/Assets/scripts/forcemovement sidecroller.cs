using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcemovementsidecroller : MonoBehaviour
{
    public Rigidbody rb; 
    public float forceAmount = 10f;
    public KeyCode keyToPress = KeyCode.Space;
    public KeyCode keyToPressw = KeyCode.F11;

    void FixedUpdate()
    {
        if (Input.GetKey(keyToPress))
        {
            rb.AddForce(Vector3.left * forceAmount, ForceMode.Impulse);
        }
    }
   

}
