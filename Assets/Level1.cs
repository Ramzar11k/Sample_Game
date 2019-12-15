using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public Player player;
    public GameObject level;
    Vector3 levelStart;
    bool playerHere = false;
    
	void Start ()
    {
        levelStart = new Vector3(45.8f, 1f, 8.07f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (playerHere == true)
            enterLevel();
	}

    void enterLevel()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(level);
            player.transform.position = levelStart;
        }
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
        if(other.gameObject.CompareTag("Player"))
        {
            playerHere = false;
        }
    }
}
