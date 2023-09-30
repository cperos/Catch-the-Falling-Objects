using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipeManager : MonoBehaviour
{
    [SerializeField] private List<PipeSO> _pipeSOs = new List<PipeSO>();

    private List<GameObject> _spawnPipes = new List<GameObject>();

    public void Init(List<PipeSO> pipeSOs)
    {
        _pipeSOs = pipeSOs;
        SpawnPipes();
    }
    public void SpawnPipes()
    {
        //for (int i = 0; i < _pipeSOs.Count; i++)
        foreach (PipeSO pipeSO in _pipeSOs)
        {
            GameObject pipe = Instantiate(pipeSO.spawnPipePrefab);

            _spawnPipes.Add(pipe);

            SpriteRenderer sr = pipe.GetComponent<SpriteRenderer>();

            sr.color = pipeSO.color;

        }
        
    }
}
