using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] string playerName;
    [SerializeField] int health;
    [SerializeField] int maxHealth;

    [SerializeField] int mana;
    [SerializeField] int maxMana;
    [SerializeField] Sprite playerBattleImage;

    [SerializeField] List<MoveBase> moves;

    public static PlayerStats Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    public string Name => playerName;
    public int Health => health;
    public int MaxHealth => maxHealth;
    public int Mana => mana;
    public int MaxMana => maxMana;
    public List<MoveBase> Move => moves;

    public Sprite PlayerImage => playerBattleImage;

    public void AddHP(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public bool GetDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            return true;
        }
        else return false;
    }

    public void AddMP(int amount)
    {
        mana += amount;
        if (mana > maxMana)
        {
            mana = maxMana;
        }
    }
}
