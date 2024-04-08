using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour, ICharacter
{
    [SerializeField] private HUD hudScript;
    
    private float _timeElapsed=0;
    private int _score=0;
    private int _currentHp;
    public int maxHp=5;

    [SerializeField] private float _maxInvincibilityTimer = 2;
    private float _invincibilityTimer;
    private bool _invincible=false;

    private void Awake()
    {
        _currentHp = maxHp;
        IncreaseScore(0);
        TakeDamage(0);

        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        _timeElapsed += Time.deltaTime;
        hudScript.UpdateTimerUI(_timeElapsed);
        
        // IFrames after taking damage
        if (_invincible)
        {
            _invincibilityTimer -= Time.deltaTime;
            if (_invincibilityTimer < 0)
            {
                _invincible = false;
            }
        }
    }

    public void IncreaseScore(int toAdd)
    {
        _score += toAdd;
        hudScript.UpdateScoreUI(_score);
    }

    public void TakeDamage(int damageToTake)
    {
        if (!_invincible)
        {
            _invincibilityTimer = _maxInvincibilityTimer;
            _invincible = true;
            _currentHp -= damageToTake;
            hudScript.UpdateHPBar((float)_currentHp, (float)maxHp);
            if (_currentHp <= 0)
            {
                hudScript.GameOver();
            }
        }
    }
}
