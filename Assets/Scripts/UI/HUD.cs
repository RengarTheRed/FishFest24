using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private Slider _hpBar;

    [SerializeField] private Transform _panelGameOver;
    
    
    // HUD Functionality
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
    }

    // In-Game Menus Button Functionality
    public void PauseResume()
    {
        // Resume Game
        if (Time.time>0)
        {
            
        }
        // Pauses Game
        else
        {
            Time.timeScale = 0;
        }
    }

    public void GameOver()
    {
        _panelGameOver.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        
    }
}
