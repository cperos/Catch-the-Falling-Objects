using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rigidbody2d;
    public float score;
    public string lootName;

    public void Init(LootSO loot)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = loot.sprite;
        spriteRenderer.color = loot.mainColor;

        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.mass = loot.mass;
        score = loot.score;
        lootName = loot.name;

        transform.localScale = loot.scale;
    }

}
