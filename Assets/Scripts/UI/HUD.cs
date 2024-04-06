using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{

    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _timerText;
    
    public void UpdateScoreUI(int newScore)
    {
        _scoreText.text = newScore.ToString("N0");
    }
    
    public void UpdateTimerUI(float newTime)
    {
        _timerText.text = newTime.ToString("N0");
    }
}
