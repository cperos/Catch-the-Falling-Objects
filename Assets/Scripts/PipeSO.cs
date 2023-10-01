using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PipeSO", menuName = "ScriptableObjects/PipeSO", order = 2)]

/// <summary>
/// ScriptableObject class containing SpawnPipeTypes.
/// </summary>
public class PipeSO : ScriptableObject
{
    public Sprite sprite;
    public int layer = 1;
    public Vector2 scale = new Vector2 (1f,1f);
    public float rotation = 0f;

    public string nameOfSpawnPipeType;
    
    public Color mainColor;
    public Color warningColor;
    public Color flashColor;

    public Vector2 spawnTimeRangeMinMax;  //Min/Max time before next drop
    public float warningDuration;
    public float flashDuration;
    public float velocity;

    public List <LootToDrop> lootDrop = new List <LootToDrop>();

}

[System.Serializable]
public struct LootToDrop
{
    public LootSO lootObject;
    public float probability;
}



