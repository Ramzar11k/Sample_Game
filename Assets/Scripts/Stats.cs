using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats : MonoBehaviour
{
    private static Stats _instance;

    public static Stats Instance
    {
        get
        {
            return _instance;
        }
        
    }

    public int playerLevel { get; set; }
    public int playerDamage { get; set; }
    public int playerXP { get; set; }
    public float playerHealth { get; set; }
    public int playerMaxHealth { get; set; }
    public int playerArmor { get; set; }
    public int playerMaxXP { get; set; }
    public int playerXPOverflow { get; set; }
    public float playerSpeed { get; set; }
    public float playerInv { get; set; }

    public int levelTarget { get; set; }

    bool heal = false;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        playerSpeed = 6f;
        playerLevel = 1;
        playerHealth = 100;
        playerXP = 0;
        playerArmor = 0;
        playerXPOverflow = 0;
        playerHealth = 100;
        playerMaxHealth = 100;
        playerMaxXP = 100;
        playerDamage = 1;
        playerInv = 0;
    }

    private void Update()
    {
        LevelUP();
    }

    void LevelUP()
    {
        if (playerXP >= playerMaxXP)
        {
            playerLevel += 1;
            playerXPOverflow = playerXP - playerMaxXP;
            heal = true;
            playerXP = 0 + playerXPOverflow;
        }
        playerDamage = playerLevel;
        playerMaxXP = 50 + 100 * playerLevel;
        playerMaxHealth = 80 + 20 * playerLevel;

        if (heal == true)
        {
            playerHealth = playerMaxHealth;
            heal = false;
        }
    } 
}