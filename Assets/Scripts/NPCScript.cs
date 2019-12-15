using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    Animator anim;
    // Use this for initialization

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start ()
    {
        anim.SetBool("gameStart", true);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
