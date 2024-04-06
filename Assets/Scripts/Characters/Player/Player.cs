using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private HUD _hudScript;

    private float timeElapsed=0;
    private int score=0;
    private void Update()
    {
        timeElapsed += Time.deltaTime;
        _hudScript.UpdateTimerUI(timeElapsed);
    }

    public void IncreaseScore(int toAdd)
    {
        score += toAdd;
        _hudScript.UpdateScoreUI(score);
    }
}
