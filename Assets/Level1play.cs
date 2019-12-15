using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1play : MonoBehaviour
{
    GameObject player;
    public GameObject enemy1;
    public GameObject level;
    List<GameObject> enemies = new List<GameObject>();
    int nrEnemies;
    float spawnCD;
    bool levelStart = true;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nrEnemies = Random.Range(25, 46);
        Stats.Instance.levelTarget = nrEnemies;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (nrEnemies > 0)
            setEnemies();
        else
            spawnEnemy();

        if (Stats.Instance.levelTarget == 0)
            levelEnd();
        if (Stats.Instance.playerHealth <= 0)
        {
            levelEndBad();
        }
    }

    void setEnemies()
    {
            enemies.Add(enemy1);
            nrEnemies--;
    }

    void spawnEnemy()
    {
        if (spawnCD <= 0 && enemies.Count > 0) 
        {
            spawnCD = 1.5f;
            GameObject spawnedEnemy = enemies[Random.Range(0, enemies.Count)];
            Instantiate(spawnedEnemy, new Vector3(Random.Range(30f, 62f), 0.7f, Random.Range(-2.5f, 21f)), Quaternion.identity);
            enemies.Remove(spawnedEnemy);
            
        }
        if (enemies.Count > 0)
        spawnCD -= Time.deltaTime;
    }

    void levelEnd()
    {
        if (levelStart == true)
        {
            Stats.Instance.playerHealth = Stats.Instance.playerMaxHealth;
            Stats.Instance.playerXP += 50;
            player.transform.position = new Vector3(0f, 1f, 0f);
            levelStart = false;
            Destroy(level, 1f);
        }
    }

    void levelEndBad()
    {
        levelStart = false;
        Destroy(level, 1f);
    }
}