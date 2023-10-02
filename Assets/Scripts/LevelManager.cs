using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int LevelNumber;
    public string LevelName;
    public string LevelDescription;

    private int _currentLevel;

    SpawnPipeManager SpawnPipeManager;


    private List<LevelDataSO> _levelDataSOList = new List<LevelDataSO>();


    public void InitializeLevel(LevelDataSO levelData)
    {
        LevelNumber = levelData.levelNumber;
        LevelName = levelData.levelName;
        LevelDescription = levelData.levelDescription;


        // Create a new game object
        GameObject spawnPipeManagerObject = new GameObject("SpawnPipeManagerObject");

        // Attach the SpawnPipeManager script to the game object
        SpawnPipeManager = spawnPipeManagerObject.AddComponent<SpawnPipeManager>();

        // Spawn the Pipes
        SpawnPipeManager.Init(levelData.pipeSOs);

        
    }

    public void Init(List<LevelDataSO> levelDataSOList)
    {
        _levelDataSOList = levelDataSOList;
    }

    public void LoadLevel(int levelNumberToLoad)
    {
        if (_levelDataSOList.Count > 0 && levelNumberToLoad <= _levelDataSOList.Count)
        {
            _currentLevel = levelNumberToLoad;

            // Initialize LevelManager script to the game object
            InitializeLevel(_levelDataSOList[_currentLevel]);

        }
        else
        {
            Debug.LogWarning("Warning! levelNumberToLoad is outside of range, no level will be loaded");
        }


    }

}
