using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Player player;
    GameObject pplayer;
    bool playerHere = false;
	// Use this for initialization
	void Start ()
    {
        pplayer = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Revive();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerHere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHere = false;
        }
    }

    void Revive()
    {
        if (playerHere == true)
        {
            Stats.Instance.playerHealth = Stats.Instance.playerMaxHealth;
            pplayer.transform.position = new Vector3(0f, 1f, 0f);
            player.dead = false;
        }
    }
}
