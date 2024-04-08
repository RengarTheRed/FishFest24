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
    [SerializeField] private Transform _panelPause;
    [SerializeField] private Transform _panelStart;

    [SerializeField] private PlayerMovement _playerMovement;
    
    
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
    // Pause trigger is on PlayerMovement
    public void PauseResume()
    {
        if (_panelStart.gameObject.activeSelf || _panelGameOver.gameObject.activeSelf)
        {
            return;
        }
        // Resume Game
        if (Time.timeScale<1)
        {
            Time.timeScale = 1;
            _panelPause.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
        }
        // Pauses Game
        else
        {
            Time.timeScale = 0;
            _panelPause.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        _panelGameOver.gameObject.SetActive(true);
    }

    public void Restart()
    {
        _playerMovement.DropBindings();
        PauseResume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        _panelStart.gameObject.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
