using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{

    [SerializeField] private float _elapsedTime;  // TODO: randomize range
    [SerializeField] private float interval;
    [SerializeField] private PipeSO _pipeSO;
    [SerializeField] private bool _isActive = false;
    [SerializeField] private SpriteRenderer _spriteRenderer;


    public void Activate()
    {


        // Calls SpawnObject after 5 seconds
        //Invoke("SpawnObject", countdown);
        StartCoroutine(FlashAndSpawnRoutine());
        _isActive = true;
    }

    public void Init(PipeSO pipeSO)
    {
        _pipeSO = pipeSO;
        _spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        _spriteRenderer.color = _pipeSO.mainColor;
        _spriteRenderer.sprite = _pipeSO.sprite;
        _spriteRenderer.sortingOrder = pipeSO.layer;
        transform.localScale = new Vector3(_pipeSO.scale.x, _pipeSO.scale.y, 1f);
        transform.eulerAngles = new Vector3(0, 0, _pipeSO.rotation);
    }

    public void Deactivate()
    {
        _isActive = false;
    }

    private void SpawnObject(int itemNumber)
    {
        LootSO lootSO = _pipeSO.lootDrop[itemNumber].lootObject;
        Debug.Log($"Spawning Item number {itemNumber}");
        // Create a new game object
        GameObject lootObject = new GameObject(lootSO.name);
        lootObject.transform.localPosition = transform.localPosition;
        Loot lootManager = lootObject.AddComponent<Loot>();
        lootManager.Init(lootSO);

        // Attach the SpawnPipeManager script to the game object
        //GameObject loot = Instantiate(_pipeSO.lootDrop[itemNumber].lootObject, transform.localPosition, Quaternion.identity);
        Destroy(lootObject, lootSO.timeToLive);
    }


    public int GetRandomLootIndex(List<LootToDrop> lootList)
    {
        // Compute the Total Weight
        float totalProbability = 0f;
        foreach (LootToDrop loot in lootList)
        {
            totalProbability += loot.probability;
        }

        // Pick a Random Value
        float randomValue = Random.Range(0f, totalProbability);

        // Determine the Selected Item's index
        for (int i = 0; i < lootList.Count; i++)
        {
            if (randomValue <= lootList[i].probability)
                return i;
            randomValue -= lootList[i].probability;
        }

        // This shouldn't happen if probabilities are set correctly
        throw new System.Exception("Failed to select a valid loot index, Check probabilities.");
    }

    private IEnumerator FlashAndSpawnRoutine()
    {
        _elapsedTime = 0f;
        interval = Random.Range(_pipeSO.spawnTimeRangeMinMax.x, _pipeSO.spawnTimeRangeMinMax.y);
        //Fade into warning color
        while (_elapsedTime < interval)
        {
            _elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(_elapsedTime / interval);
            _spriteRenderer.color = Color.Lerp(_pipeSO.mainColor, _pipeSO.warningColor, t);
            yield return null;
        }


        // Wait for the warning duration
        yield return new WaitForSeconds(_pipeSO.warningDuration);


        // Set to flash color
        _spriteRenderer.color = _pipeSO.flashColor;

        // set a lootIndex
        int lootIndex = GetRandomLootIndex(_pipeSO.lootDrop);

        // spawn the loot of that IndexNumber
        SpawnObject(lootIndex);
        


        yield return new WaitForSeconds(_pipeSO.flashDuration);

        ResetColor();

        // If still active, start process over again
        if (_isActive) 
        {
            StartCoroutine(FlashAndSpawnRoutine());
        }
    }

    public void ResetColor()
    {
        _spriteRenderer.color = _pipeSO.mainColor;
    }
}
