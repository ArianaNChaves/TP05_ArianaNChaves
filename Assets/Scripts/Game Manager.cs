using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private UiHandler gameplayUiHandler;
    [SerializeField] private GameObject player;
    private void Awake()
    {
        playerHealth.PlayerDeath += GameOver;
        gameplayUiHandler.IsPaused += StopPlayer;
    }
    private void Start()
    {
        AudioManager.Instance.PlayMusic("Main Theme");
    }

    private void OnDestroy()
    {
        playerHealth.PlayerDeath -= GameOver;
        gameplayUiHandler.IsPaused -= StopPlayer;

    }

    private void GameOver()
    {
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.PlayEffect("Game Over");
    }

    private void StopPlayer(bool active)
    {
        player.SetActive(!active);
    }
    
}
