using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGuy : MonoBehaviour
{
    Rigidbody blueGuyRigidbody;
    float posx;
    float posy;
    float posz;
    
	// Use this for initialization
	void Start ()
    {
        blueGuyRigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        FixRotation();
    }

    void FixRotation()
    {
        float y = transform.eulerAngles.y;
        float x = transform.eulerAngles.x;
        float z = transform.eulerAngles.z;
        if (x !=0 || z != 0)
        {
            Vector3 v3;
            v3.x = 0;
            v3.y = y;
            v3.z = 0;
            transform.eulerAngles = v3;
        }
    }

}
