using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour, Interactable
{


    [SerializeField] BossBase boss;

     string bossName;
     string bossDescription;

     Sprite bossNPCSprite;
     Sprite bossBattleImage;

    public int current_health;
    
    SpriteRenderer sprite_renderer;

    public string Name => bossName;
    public string Description => bossDescription;

    public Sprite BattleImage => bossBattleImage;

    
    public IEnumerator Interact(Transform initiator)
    {

        yield return new WaitForSeconds(1);
        if (current_health > 0)
        {
            current_health -= 10;
        }
    }

    public void Awake()
    {
        sprite_renderer = GetComponentInParent<SpriteRenderer>();
        bossNPCSprite = boss.NPCSprite;
        bossBattleImage = boss.BattleImage;

        bossName = boss.bossName;
        bossDescription = boss.bossDescription;

    }
    public void Start()
    {
        current_health = boss.maxHealth;
        sprite_renderer.sprite = bossNPCSprite;
        transform.localScale = new Vector3(1,1,1);
        //sprite_renderer.enabled = true;
        gameObject.GetComponent<BoxCollider2D>().size = sprite_renderer.sprite.bounds.size;


    }

    public void Attack()
    {
        throw new NotImplementedException();
    }
}

