using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICanvasManager : MonoBehaviour
{
    [SerializeField] private RectTransform healthBarFillTransform;
    [SerializeField] private RectTransform timerFillTransform;

    [SerializeField] private float hpX;
    [SerializeField] private float timerX;

    private float hpY;
    [SerializeField] private float timerY; 

    [SerializeField] private TextMeshProUGUI _score;



    public float testValue;
    public bool test;



    // Timer variables
    private float _maxTime;
    private float targetWidth;
    private float currentWidth;
    private const float lerpSpeed = 1.0f;

    //private void Update()
    //{
    //    if(test)
    //    {
    //        test = false;
    //        ModifyHealthBarFill(testValue);
    //    }
    //}

    private void OnEnable()
    {
        Player.onHealthModification += ModifyHealthBarFill;
        Player.onScoreModification += ModifyScore;

        TimerManager.onTimerStart += SetMaxTime;
        TimerManager.onTimerTick += ModifyTimer;

    }

    private void OnDisable()
    {
        Player.onHealthModification -= ModifyHealthBarFill;
        Player.onScoreModification -= ModifyScore;

        TimerManager.onTimerStart -= SetMaxTime;
        TimerManager.onTimerTick -= ModifyTimer;

    }

    private void Start()
    {
        hpY = healthBarFillTransform.sizeDelta.x;
        timerY = timerFillTransform.sizeDelta.x;

        currentWidth = timerFillTransform.sizeDelta.x;
        targetWidth = currentWidth;

        //_score.text = "0";
    }

    private void Update()
    {
        // Lerp the current width towards the target width
        currentWidth = Mathf.Lerp(currentWidth, targetWidth, lerpSpeed * Time.deltaTime);

        timerFillTransform.sizeDelta = new Vector2(currentWidth, timerFillTransform.sizeDelta.y);
    }

    public void ModifyHealthBarFill(float percentFill)
    {
        float mappedValue = Mathf.Lerp( hpX, hpY, percentFill / 100f );
        healthBarFillTransform.sizeDelta = new Vector2(mappedValue, healthBarFillTransform.sizeDelta.y);
    }

    public void ModifyScore(float score)
    {
        _score.text = score.ToString();
    }

    public void SetMaxTime(float maxTime)
    {
        _maxTime = maxTime;
    }

    private void ModifyTimer(float time)
    {
        Debug.Log("time is " + time);
        targetWidth = Mathf.Lerp(timerX, timerY, time / _maxTime);

        //timerFillTransform.sizeDelta = new Vector2(mappedValue, timerFillTransform.sizeDelta.y);
    }

}
