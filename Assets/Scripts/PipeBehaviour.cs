using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PipeBehaviour : MonoBehaviour
{

    [SerializeField] private float _elapsedTime;  // TODO: randomize range
    [SerializeField] private float interval;
    [SerializeField] private PipeSO _pipeSO;
    [SerializeField] private bool _isActive = false;
    [SerializeField] private SpriteRenderer _spriteRenderer;


    public void Activate(PipeSO pipeSO)
    {
        _pipeSO = pipeSO;
        setMainColor();
        // Calls SpawnObject after 5 seconds
        //Invoke("SpawnObject", countdown);
        StartCoroutine(FlashAndSpawnRoutine());
        _isActive = true;
    }

    public void Deactivate()
    {
        _isActive = false;
    }

    private void SpawnObject(int itemNumber)
    {
        Debug.Log($"Spawning Item number {itemNumber}");
        GameObject loot = Instantiate(_pipeSO.lootDrop[itemNumber].lootObject, transform.localPosition, Quaternion.identity);
        Destroy(loot, 3f);
    }

    private void setFlashColor()
    {
        setColor(_pipeSO.flashColor);
    }

    public void setMainColor()
    {
        setColor(_pipeSO.mainColor);
    }

    private void setColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    private IEnumerator FlashAndSpawnRoutine()
    {
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
        setFlashColor();
        
        SpawnObject(Random.Range(0, _pipeSO.lootDrop.Count));
        


        yield return new WaitForSeconds(_pipeSO.flashDuration);

        // Reset to original color
        setMainColor();

        // If still active, start process over again
        if (_isActive) 
        {
            _elapsedTime = 0f;
            StartCoroutine(FlashAndSpawnRoutine());
        }
    }



    }
