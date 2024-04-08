using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    [SerializeField] private HUD _hudScript;
    
    private float timeElapsed=0;
    private int score=0;
    private int currentHP;
    public int maxHP=5;

    private void Awake()
    {
        currentHP = maxHP;
        IncreaseScore(0);
        TakeDamage(0);

        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }

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

    public void TakeDamage(int damageToTake)
    {
        currentHP -= damageToTake;
        _hudScript.UpdateHPBar((float)currentHP, (float)maxHP);
        if (currentHP <= 0)
        {
            _hudScript.GameOver();
        }
    }
}
