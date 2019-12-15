using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemies 
{
    public string enemyName;
    public int enemyHealth;
    public int enemyDamage;
    public int enemyArmor;
    public int enemyXP;
    public List<Enemies> listOfEnemies;

    public Enemies(string name, int health, int damage, int armor, int xp)
    {
        this.enemyName = name;
        this.enemyHealth = health;
        this.enemyDamage = damage;
        this.enemyArmor = armor;
        this.enemyXP = xp;
    }

    public void AddEnemy(string name,int hp,int armor,int attack, int xp)
    {
        var enemy = new Enemies(name, hp, armor, attack, xp);
        listOfEnemies.Add(enemy);
    }
}