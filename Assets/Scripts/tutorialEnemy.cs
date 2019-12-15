using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialEnemy : MonoBehaviour
{
    Enemies enemy1;
    private bool damaged = false;
    Transform player;
    UnityEngine.AI.NavMeshAgent nav;
    bool playerDamage = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Start ()
    {
        enemy1 = new Enemies("tutorialEnemy", 2, 10, 0, 4);
    }
	
	// Update is called once per frame
	void Update ()
    {
        nav.SetDestination(player.position);
        transform.LookAt(player);
        if (enemy1.enemyHealth <= 0)
            Death();
        Damaged();
        playerDamaged();
        
        if (Stats.Instance.playerHealth <= 0)
        {
            selfDestroy();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
            damaged = true;
        if (other.gameObject.CompareTag("Player"))
            playerDamage = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerDamage = false;
        }
    }

    void Damaged()
    {
        if (damaged == true)
        {
            enemy1.enemyHealth -= (Stats.Instance.playerDamage - enemy1.enemyArmor);
            damaged = false;
        }
    }       

    void Death()
    {
        Destroy(gameObject);
        Stats.Instance.playerXP += enemy1.enemyXP;
        Stats.Instance.levelTarget -= 1;
    }

    void playerDamaged()
    {
        if (Stats.Instance.playerInv <= 0 && playerDamage == true)
        {
            Stats.Instance.playerInv = 1f;
            Stats.Instance.playerHealth -= (enemy1.enemyDamage - Stats.Instance.playerArmor);
        }
        Stats.Instance.playerInv -= Time.deltaTime;
    }

    void selfDestroy()
    {
        Destroy(gameObject);
    }
}
