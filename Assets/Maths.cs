using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maths : MonoBehaviour
{
    public float height;
    public float lenght;
    public float h;
    public float l;
    float qheight;
    float qlenght;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
            qheight = (height / 8.9f) * 7.8f;
            qlenght = (lenght / 12.7f) * 10.8f;

        l = qlenght;
        h = qheight;
    }
}
