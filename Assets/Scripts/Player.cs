using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    public Rigidbody2D rb2d;
    private BoxCollider2D boxCollider2D;

    public float playerScore;
    public float playerHealth;

    public delegate void HealthModification(float percent);
    public static event HealthModification onHealthModification;

    public delegate void ScoreModification(float score);
    public static event ScoreModification onScoreModification;

    public Vector2 screenBounds;

    private GameObject explosion;
    private AudioClip deathSound;

    private AudioSource playerAudio;


    public void Init(PlayerSO playerSO)
    {
        speed = playerSO.speed;
        rb2d = gameObject.AddComponent<Rigidbody2D>();
        rb2d.constraints = RigidbodyConstraints2D.FreezePositionY;
        rb2d.drag = playerSO.drag;

        boxCollider2D = gameObject.AddComponent<BoxCollider2D>();

        boxCollider2D.offset = playerSO.colliderOffset;
        boxCollider2D.size = playerSO.colliderSize;

        playerHealth = playerSO.playerHealth;

        AddPoints(0); // broadcast the initial score
        ModifyHealth(0); // broadcast initial health
        explosion = playerSO.explosionPrefab;

        deathSound = playerSO.deathSound;
        playerAudio = gameObject.AddComponent<AudioSource>();



        CalculateScreenBounds();
    }

    private void OnEnable()
    {

        TimerManager.onTimerTick += CheckTime;

    }

    private void OnDisable()
    {

        TimerManager.onTimerTick -= CheckTime;

    }

    private void CheckTime(float time)
    {
        if (time < 0)
        {
            KillPLayer();
        }
    }

    private void KillPLayer()
    {

        playerAudio.clip = deathSound;
        playerAudio.Play();

        Instantiate(explosion, transform.position, Quaternion.identity);
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
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
        float originalHealth = playerHealth;

        playerHealth += hp;
        if (playerHealth > 100)
        {
            playerHealth = 100;
        }

        if (onHealthModification != null)
        {
            onHealthModification(playerHealth);
        }


        if (playerHealth < originalHealth)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            KillPLayer();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        LootBehaviour lb = go.GetComponentInChildren<LootBehaviour>();
        lb.Execute(this);

        Destroy(go);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // the horizontal axis (arrow, a,d, joystick ets...)
        Vector2 moveForce = new Vector2(horizontalInput * speed, 0);
        rb2d.AddForce(moveForce);

        wrapScreen();
        

    }

    private void wrapScreen()
    {
        float shift = 1.25f;

        if (transform.position.x < screenBounds.x - shift)
        {
            Debug.Log("Offscreen low");
            Vector3 v3 = new Vector3(screenBounds.y, transform.position.y, transform.position.z);
            transform.position = v3;
        }
        
        if (transform.position.x > screenBounds.y + shift)
        {
            Debug.Log("Offscreen high");
            Vector3 v3 = new Vector3(screenBounds.x, transform.position.y, transform.position.z);
            transform.position = v3;
        }
    }
    


    private void CalculateScreenBounds()
    {
        Camera mainCamera = Camera.main;

        // Get the left bound
        screenBounds.x = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, mainCamera.nearClipPlane)).x;

        // Get the right bound
        screenBounds.y = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.nearClipPlane)).x;
    }
}
