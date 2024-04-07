using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private Slider _hpBar;
    
    public void UpdateScoreUI(int newScore)
    {
        _scoreText.text = newScore.ToString("N0");
    }
    
    public void UpdateTimerUI(float newTime)
    {
        _timerText.text = newTime.ToString("N0");
    }

    public void UpdateHPBar(float currentHP, float maxHP)
    {
        _hpBar.value = currentHP / maxHP;
        Debug.Log(currentHP/maxHP);
    }
}
