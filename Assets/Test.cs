using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject enemy;
    public Vector3 pos;

	// Use this for initialization
	void Start ()
    {
        pos = enemy.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.T))
        {
            enemy.transform.position = new Vector3(0f, 1f, 0f);
        }
	}
}
