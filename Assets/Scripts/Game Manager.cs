using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public event Action Win;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private UiHandler gameplayUiHandler;
    [SerializeField] private GameObject player;
    
    private int _enemyDeathCount = 0;
    private int _totalEnemies;
    private void Awake()
    {
        playerHealth.PlayerDeath += GameOver;
        gameplayUiHandler.IsPaused += StopPlayer;
        EnemyHealth.OnEnemyDeath += VerifyWinCondition;
    }
    private void Start()
    {
        AudioManager.Instance.PlayMusic("Main Theme");
        SearchTotalEnemies();
    }

    private void OnDestroy()
    {
        playerHealth.PlayerDeath -= GameOver;
        gameplayUiHandler.IsPaused -= StopPlayer;
        EnemyHealth.OnEnemyDeath -= VerifyWinCondition;
        
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

    private void VerifyWinCondition()
    {
        _enemyDeathCount++;
        
        if (_totalEnemies == _enemyDeathCount)
        {
            Win?.Invoke();
        }
        
    }

    private void SearchTotalEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        _totalEnemies = enemies.Length;
        
        gameplayUiHandler.UpdateEnemiesInfo();
    }

    public int GetTotalEnemies()
    {
        return _totalEnemies;
    }

    public int GetTotalEnemiesDead()
    {
        return _enemyDeathCount;
    }
    
}
