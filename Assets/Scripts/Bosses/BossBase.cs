using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Bosses/Create new boss")]
public class BossBase : ScriptableObject
{

    
    [SerializeField] string bossName;

    [TextArea]
    [SerializeField] string bossDescription;

    [SerializeField] int maxHealth;
    [SerializeField] int damage;

    [SerializeField] Sprite bossNPCSprite;
    [SerializeField] Sprite bossBattleImage;
    [SerializeField] Sprite bossBattleBackground;

    

    [SerializeField] List<AttackBase> possibleAttacks;

    public string Name => bossName;
    public string Description => bossDescription;

    public int MaxHealth => maxHealth;
    public int Damage => damage;
    public Sprite NPCSprite => bossNPCSprite;
    public Sprite BattleImage => bossBattleImage;

    public Sprite BattleBackground => bossBattleBackground;

    public List<AttackBase> PossibleAttacks => possibleAttacks;

    public AttackBase Attack()
    {
        if (possibleAttacks.Count > 0)
        {
            AttackBase chosenAttack = possibleAttacks.PickRandom();
            return chosenAttack;
        }
        else return default;
    }
}
