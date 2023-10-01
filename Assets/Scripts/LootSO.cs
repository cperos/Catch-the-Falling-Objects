using UnityEngine;

[CreateAssetMenu(fileName = "LootSO", menuName = "ScriptableObjects/LootSO", order = 3)]

/// <summary>
/// ScriptableObject class containing LootTypes.
/// </summary>
public class LootSO : ScriptableObject
{
    public string nameOfLoot;
    public Sprite sprite;
    public int layer = 0;
    public Color mainColor;
    public float score;
    public float mass;
    public float timeToLive;

    public Vector2 scale;
}
