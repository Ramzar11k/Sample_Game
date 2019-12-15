using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordAttacking : MonoBehaviour
{
    BoxCollider boxCollider;
	// Use this for initialization
	void Start ()
    {
        boxCollider = GetComponent<BoxCollider>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Attacking();	
	}

    void Attacking ()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            boxCollider.enabled = true;
        else
            boxCollider.enabled = false;
    }
}
