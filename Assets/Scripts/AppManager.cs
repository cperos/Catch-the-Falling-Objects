using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    public LevelManager levelManager;
    public GameObject levelManagerObject;
    public List <LevelDataSO> levelDataSOList = new List<LevelDataSO>();
    public UICanvasManager uiCanvasManager;


    public bool gameActive;
    private int startingLevel;


    // Start is called before the first frame update
    void Start()
    {
        // Create a new game object
        levelManagerObject = new GameObject("LevelManagerObject");
        // Attach the LevelManager script to the game object
        levelManager = (LevelManager)levelManagerObject.AddComponent<LevelManager>();
        levelManager.Init(levelDataSOList);
        levelManager.LoadLevel(startingLevel);


    }
}
