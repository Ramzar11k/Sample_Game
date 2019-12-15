using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public GameObject target;
    public Vector3 pos;

	// Use this for initialization
	void Start ()
    {
        target = this.gameObject;
        pos = target.transform.position;	
	}

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x != pos.x || transform.position.y != pos.y)
        {
            target.transform.position = pos;
        }
        FixRotation();
	}

    void FixRotation()
    {
        float y = transform.eulerAngles.y;
        float x = transform.eulerAngles.x;
        float z = transform.eulerAngles.z;
        if (x != 0 || z != 0 || y != -90)
        {
            Vector3 v3;
            v3.x = 0;
            v3.y = -90;
            v3.z = 0;
            transform.eulerAngles = v3;
        }
    }
}
