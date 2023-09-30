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
    public GameObject spawnPipePrefab;

    public string nameOfSpawnPipeType;
    public Color color;
    public Color flashColor;
    public float fashTime;
    public float velocity;


    // public Loot To Drop


}
