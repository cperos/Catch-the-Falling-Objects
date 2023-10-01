using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private List <PlayerSO> _playerSOs = new List <PlayerSO>();

    [SerializeField] private Vector3 _bottomLeftWorldPos;
    [SerializeField] private Vector3 _bottomRightWorldPos;

    public void Init(List<PlayerSO> playerSOs)
    {
        InitializePlayerSpawnRange();
        _playerSOs = playerSOs;
        DistributePlayerObjects();
    }

    public void LoadPlayers()
    {
        foreach (PlayerSO playerSO in _playerSOs)
        {
            LoadPlayer(playerSO);
        }
    }

    public GameObject LoadPlayer(PlayerSO playerSO)
    {
        GameObject playerObject = new GameObject(playerSO.nameOfPlayer);

        PlayerMovement playerMovement = (PlayerMovement)playerObject.AddComponent<PlayerMovement>();
        playerMovement.speed = playerSO.speed;

        SpriteRenderer spriteRenderer = (SpriteRenderer)playerObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = playerSO.sprite;
        spriteRenderer.color = playerSO.mainColor;

        spriteRenderer.sortingOrder = playerSO.layer;

        playerObject.transform.localScale = new Vector3 (playerSO.scale.x, playerSO.scale.y, 1f);
        playerObject.transform.eulerAngles = new Vector3(0, 0, playerSO.roatation);

        return playerObject;

    }

    private void DistributePlayerObjects()
    {
        int objectCount = _playerSOs.Count;
        for (int i = 0; i < objectCount; i++)
        {
            float lerpValue = (float)i / (objectCount - 1);
            Vector3 interpolatedPosition = Vector3.Lerp(_bottomLeftWorldPos, _bottomRightWorldPos, lerpValue);

            GameObject playerObject = LoadPlayer(_playerSOs[i]);  // Assuming LoadPlayer now returns the GameObject it created.
            playerObject.transform.localPosition = interpolatedPosition;
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
    }
}
