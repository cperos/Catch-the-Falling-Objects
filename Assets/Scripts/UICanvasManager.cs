using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICanvasManager : MonoBehaviour
{
    [SerializeField] private RectTransform healthBarFillTransform;
    [SerializeField] private Vector2 size;

    [SerializeField] private TextMeshProUGUI _score;



    public float testValue;
    public bool test;
    private void Update()
    {
        if(test)
        {
            test = false;
            ModifyHealthBarFill(testValue);
        }
    }

    private void OnEnable()
    {
        Player.onHealthModification += ModifyHealthBarFill;
        Player.onScoreModification += ModifyScore;
    }

    private void OnDisable()
    {
        Player.onHealthModification -= ModifyHealthBarFill;
        Player.onScoreModification -= ModifyScore;
    }

    private void Start()
    {
        size.y = healthBarFillTransform.sizeDelta.x;
    }

    public void ModifyHealthBarFill(float percentFill)
    {
        float mappedValue = Mathf.Lerp( size.x, size.y, percentFill / 100f );
        healthBarFillTransform.sizeDelta = new Vector2(mappedValue, healthBarFillTransform.sizeDelta.y);
    }

    public void ModifyScore(float score)
    {
        _score.text = score.ToString();
    }

}
