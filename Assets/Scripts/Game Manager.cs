using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerHealth player;
    [SerializeField] private GameObject gameOverPanel;
    private void Awake()
    {
        player.PlayerDeath += GameOver;
    }
    private void Start()
    {
        AudioManager.Instance.PlayMusic("Main Theme");
    }

    private void OnDestroy()
    {
        player.PlayerDeath -= GameOver;
    }

    private void GameOver()
    {
        StopTime();
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.PlayEffect("Game Over");
    }

    private void StopTime()
    {
        Time.timeScale = 1;
    }

    private void ReanudeTime()
    {
        Time.timeScale = 1;
    }
    
}
