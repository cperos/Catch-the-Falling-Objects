using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "ScriptableObjects/PlayerSO", order = 4)]

/// <summary>
/// ScriptableObject class containing the Player.
/// </summary>
public class PlayerSO : ScriptableObject
{
    public string nameOfPlayer;
    public Sprite sprite;
    public Color mainColor;
    public int layer = 1;
    public float playerScore;
    public float playerHealth;
    public float mass;

    public Vector2 scale;
    public float roatation;

    public float speed;
    public float drag;

    public Vector2 colliderOffset;
    public Vector2 colliderSize;

    public float yShift;

    public GameObject explosionPrefab;
    public AudioClip deathSound;

}
