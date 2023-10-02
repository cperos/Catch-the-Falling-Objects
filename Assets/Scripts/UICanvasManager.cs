using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICanvasManager : MonoBehaviour
{
    [SerializeField] private RectTransform healthBarFillTransform;
    [SerializeField] private RectTransform timerFillTransform;

    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private Vector2 hpMinMax;
    [SerializeField] private float timerMin;

    private float timerY; 

    [SerializeField] private TextMeshProUGUI _score;

    // Timer variables
    private float _maxTime;
    private float targetWidth;
    private float currentWidth;
    private const float lerpSpeed = 1.0f;


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
        gameOverPanel.SetActive(false);
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
        float mappedValue = Mathf.Lerp( hpMinMax.x, hpMinMax.y, percentFill / 100f );
        healthBarFillTransform.sizeDelta = new Vector2(mappedValue, healthBarFillTransform.sizeDelta.y);

        if (percentFill <= 0)
        {
            gameOverPanel.SetActive(true);
        }
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
        targetWidth = Mathf.Lerp(timerMin, timerY, time / _maxTime);
        if (time <= 0)
        {
            gameOverPanel.SetActive(true);
        }
    }

}
