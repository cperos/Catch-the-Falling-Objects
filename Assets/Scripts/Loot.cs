using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rigidbody2d;
    public float score;
    public string lootName;

    public void Init(LootSO loot)
    {

        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = loot.sprite;
        spriteRenderer.color = loot.mainColor;

        rigidbody2d = gameObject.AddComponent<Rigidbody2D>();
        rigidbody2d.mass = loot.mass;
        score = loot.score;
        lootName = loot.name;

        transform.localScale = new Vector3(loot.scale.x, loot.scale.y, 1f);
    }

}
