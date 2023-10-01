using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    Rigidbody2D rb2d;
    BoxCollider2D boxCollider2D;

    public float playerScore;
    public float playerHealth;

    public delegate void HealthModification(float percent);
    public static event HealthModification onHealthModification;

    public delegate void ScoreModification(float score);
    public static event ScoreModification onScoreModification;

    public void Init(PlayerSO playerSO)
    {
        _speed = playerSO.speed;
        rb2d = gameObject.AddComponent<Rigidbody2D>();
        rb2d.constraints = RigidbodyConstraints2D.FreezePositionY;
        rb2d.drag = playerSO.drag;

        boxCollider2D = gameObject.AddComponent<BoxCollider2D>();

        boxCollider2D.offset = playerSO.colliderOffset;
        boxCollider2D.size = playerSO.colliderSize;

        playerHealth = playerSO.playerHealth;
    }

    public void AddPoints(float points)
    {
        playerScore += points;

        if (onScoreModification != null) 
        {
            onScoreModification(playerScore);
        }
    }

    public void ModifyHealth(float hp)
    {
        playerHealth += hp;
        if (playerHealth > 100)
        {
            playerHealth = 100;
        }

        if (onHealthModification != null)
        {
            onHealthModification(playerHealth);
        }

        if (playerHealth <= 0)
        {
            playerHealth = 0;
            //TODO GameOver
            Destroy(gameObject);

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        LootBehaviour lb = go.GetComponentInChildren<LootBehaviour>();
        lb.Execute(this);

        Destroy(go);
    }
    //Vector3 position = new Vector3 (0, 0, 0);
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // the horizontal axis (arrow, a,d, joystick ets...)
        Vector2 moveForce = new Vector2(horizontalInput * _speed, 0);
        rb2d.AddForce(moveForce);
    }
}
