using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{


    [SerializeField] BossBase boss;
    public BossBase Base => boss;

    SpriteRenderer sprite_renderer;


    

    public void Awake()
    {
        sprite_renderer = GetComponentInParent<SpriteRenderer>();


    }
    public void Start()
    {
        sprite_renderer.sprite = boss.NPCSprite;
        transform.localScale = new Vector3(1,1,1);
        //sprite_renderer.enabled = true;
        gameObject.GetComponent<BoxCollider2D>().size = sprite_renderer.sprite.bounds.size;

    }
}

