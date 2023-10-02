using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class SpawnPipeManager : MonoBehaviour
{
    [SerializeField] private List<PipeSO> _pipeSOs = new List<PipeSO>();

    private List<GameObject> _spawnPipes = new List<GameObject>();

    [SerializeField] private Vector3 _topLeftScreenPos;
    [SerializeField] private Vector3 _topLeftWorldPos;

    // Get the top right corner
    [SerializeField] private Vector3 _topRightScreenPos;
    [SerializeField] private Vector3 _topRightWorldPos;


    private void DistributePipeObjects()
    {
        int objectCount = _spawnPipes.Count;
        for (int i = 0; i < objectCount; i++)
        {
            float lerpValue = (float)i / (objectCount - 1);
            Vector3 interpolatedPosition = Vector3.Lerp(_topLeftWorldPos, _topRightWorldPos, lerpValue);

            _spawnPipes[i].transform.position = interpolatedPosition;
        }
    }



    private void InitializeSpawnRange()
    {
        Camera mainCamera = Camera.main;

        // Get the top left corner
        _topLeftScreenPos = new Vector3(0, Screen.height, mainCamera.nearClipPlane);
        _topLeftWorldPos = mainCamera.ScreenToWorldPoint(_topLeftScreenPos);

        // Get the top right corner
        _topRightScreenPos = new Vector3(Screen.width, Screen.height, mainCamera.nearClipPlane);
        _topRightWorldPos = mainCamera.ScreenToWorldPoint(_topRightScreenPos);

        // Shift positions upward by x units
        float yShiftAmount = -.5f; // replace this with the amount you want to shift by
        float xShiftAmount = 1.25f; // replace this with the amount you want to shift by
        _topLeftWorldPos.y += yShiftAmount;
        _topRightWorldPos.y += yShiftAmount;
        _topLeftWorldPos.x += xShiftAmount;
        _topRightWorldPos.x -= xShiftAmount;

    }

    public void Init(List<PipeSO> pipeSOs)
    {
        _pipeSOs = pipeSOs;
        InitializeSpawnRange();
        SpawnPipes();
        DistributePipeObjects();
        ActivatePipes();

    }

    public void SpawnPipes()
    {
        //for (int i = 0; i < _pipeSOs.Count; i++)
        foreach (PipeSO pipeSO in _pipeSOs)
        {
            
            //GameObject pipe = Instantiate(pipeSO.spawnPipePrefab);
            
            GameObject pipe = new GameObject(pipeSO.name);

            Pipe pipeBehaviour = pipe.AddComponent<Pipe>();

            pipeBehaviour.Init(pipeSO);
 

            _spawnPipes.Add(pipe);



        }
        
    }

    private void ActivatePipes()
    {
        //foreach(GameObject pipeGO in _spawnPipes)
        for (int i = 0; i < _spawnPipes.Count; i++)
        {
            Pipe pipeBehaviour = _spawnPipes[i].GetComponent<Pipe>();;
            pipeBehaviour.Activate();
            //pipeBehaviour.setPipeSO(_pipeSOs[i]);

        }
    }
}
