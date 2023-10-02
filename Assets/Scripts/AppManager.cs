using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    private LevelManager levelManager;
    private GameObject levelManagerObject;

    private PlayerManager playerManager;
    private GameObject playerManagerObject;

    private TimerManager timerManager;
    private GameObject timerManagerObject;

    [SerializeField] private float GameTimerSeconds;

    public List <LevelDataSO> levelDataSOList = new List<LevelDataSO>();


    public List<PlayerSO> playerSOList = new List<PlayerSO>();
    //public UICanvasManager uiCanvasManager;


    public static bool gameActive;
    private int startingLevel;
    private AudioSource gameAudio;


    // Start is called before the first frame update
    void Start()
    {
        // Create a new game object
        levelManagerObject = new GameObject("LevelManagerObject");
        // Attach the LevelManager script to the game object
        levelManager = levelManagerObject.AddComponent<LevelManager>();
        levelManager.Init(levelDataSOList);
        levelManager.LoadLevel(startingLevel);

        //game audio
        gameAudio = gameObject.AddComponent<AudioSource>();
        gameAudio.clip = levelDataSOList[startingLevel].music;
        gameAudio.volume = 0.5f;
        gameAudio.Play();

        // Create a new game object
        playerManagerObject = new GameObject("playerManagerObject");
        playerManager = playerManagerObject.AddComponent<PlayerManager>();
        playerManager.Init(playerSOList);

        // Create a new game object
        timerManagerObject = new GameObject("timerManagerObject");
        timerManager = timerManagerObject.AddComponent<TimerManager>();
        timerManager.Init(GameTimerSeconds);
        timerManager.StartTimer();



    }


}
