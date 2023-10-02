using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]

/// <summary>
/// ScriptableObject class containing level information.
/// </summary>
public class LevelDataSO : ScriptableObject
{
    public int levelNumber;
    public string levelName;
    public string levelDescription;
    //public int numberOfSpawnPipes;  // the number of spawnPipes
    public float spawnLength;  // SpawnPipes distributed over percentage of top of screen (50 = 50%)

    public List <PipeSO> pipeSOs = new List <PipeSO>();

    public Vector2 spawnRateRange; // x = min, y = max

    public AudioClip music;


}
