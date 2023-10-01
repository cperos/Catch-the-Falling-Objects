using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    //public int numberOfPlayers;
    private LevelManager levelManager;
    private GameObject levelManagerObject;

    private PlayerManager playerManager;
    private GameObject playerManagerObject;

    public List <LevelDataSO> levelDataSOList = new List<LevelDataSO>();


    public List<PlayerSO> playerSOList = new List<PlayerSO>();
    //public UICanvasManager uiCanvasManager;


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

        // Create a new game object
        playerManagerObject = new GameObject("playerManagerObject");
        playerManager = (PlayerManager)playerManagerObject.AddComponent<PlayerManager>();
        playerManager.Init(playerSOList);
        //playerManager.LoadPlayers();

        //levelManager


    }
}
