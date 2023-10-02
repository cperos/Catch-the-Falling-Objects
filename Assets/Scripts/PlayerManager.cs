using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private List <PlayerSO> _playerSOs = new List <PlayerSO>();
    [SerializeField] private List<GameObject> _players = new List<GameObject>();

    [SerializeField] private Vector3 _bottomLeftWorldPos;
    [SerializeField] private Vector3 _bottomRightWorldPos;

    [SerializeField] private float yShiftAmount;

    public void Init(List<PlayerSO> playerSOs)
    {
        if (playerSOs.Count == 0) 
        {
            Debug.LogWarning("No Players to Load");
            return;
        }
        _playerSOs = playerSOs;

        CreateAllPlayers();
        InitializePlayerSpawnRange();
        DistributePlayerObjects();
        

    }

    public void CreatePlayer(PlayerSO playerSO)
    {
        yShiftAmount = playerSO.yShift;
        GameObject playerObject = new GameObject(playerSO.nameOfPlayer);


        Player player = playerObject.AddComponent<Player>();


        player.Init(playerSO);

        SpriteRenderer spriteRenderer = (SpriteRenderer)playerObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = playerSO.sprite;
        spriteRenderer.color = playerSO.mainColor;

        spriteRenderer.sortingOrder = playerSO.layer;

        playerObject.transform.localScale = new Vector3 (playerSO.scale.x, playerSO.scale.y, 1f);
        playerObject.transform.eulerAngles = new Vector3(0, 0, playerSO.roatation);



        _players.Add(playerObject);

    }

    private void DistributePlayerObjects()
    {
        int objectCount = _players.Count;

        for (int i = 0; i < objectCount; i++)
        {
            float lerpValue = ((float)i + 1) / (objectCount + 1);
            Vector3 interpolatedPosition = Vector3.Lerp(_bottomLeftWorldPos, _bottomRightWorldPos, lerpValue);
            _players[i].transform.position = interpolatedPosition;
        }
    }

    private void CreateAllPlayers()
    {
        foreach(PlayerSO playerSO in _playerSOs)
        {
            CreatePlayer(playerSO);
        }
    }

    private void InitializePlayerSpawnRange()
    {
        Camera mainCamera = Camera.main;

        // Get the bottom left corner
        _bottomLeftWorldPos = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));

        // Get the bottom right corner
        _bottomRightWorldPos = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, mainCamera.nearClipPlane));

        // Optionally, you can shift the positions left/right or up/down as necessary.
        // Shift positions upward by x units
        float xShiftAmount = 1.25f; // replace this with the amount you want to shift by
        _bottomLeftWorldPos.y += yShiftAmount;
        _bottomRightWorldPos.y += yShiftAmount;
        _bottomLeftWorldPos.x += xShiftAmount;
        _bottomRightWorldPos.x -= xShiftAmount;
    }

}
