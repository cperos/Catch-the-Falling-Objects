using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rigidbody2d;
    public float score;
    public string lootName;

    public AudioClip collectionSound;

    GameObject behaviourHandler;

    CircleCollider2D circleCollider;
    public void Init(LootSO loot)
    {

        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = loot.sprite;
        spriteRenderer.color = loot.mainColor;
        spriteRenderer.sortingOrder = loot.layer;

        rigidbody2d = gameObject.AddComponent<Rigidbody2D>();
        rigidbody2d.mass = loot.mass;
        score = loot.value;
        lootName = loot.name;

        transform.localScale = new Vector3(loot.scale.x, loot.scale.y, 1f);
        //gameObject.tag = loot.type.ToString();

        circleCollider = gameObject.AddComponent<CircleCollider2D>();
        circleCollider.isTrigger = true;

        behaviourHandler = Instantiate(loot.behaviourHandler, transform);

        collectionSound = loot.collectionSound;

        LootBehaviour lootBehaviour = behaviourHandler.GetComponent<LootBehaviour>();
        lootBehaviour.Init(loot.value);
    }

}
