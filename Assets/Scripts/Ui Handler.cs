using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UiHandler : MonoBehaviour
{
    public event Action<bool> IsPaused;
    
    [Header("Buttons")] 
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button settingsBackButton;
    [SerializeField] private Button backToMainMenuButton;

    [Header("Panels")] 
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject losePanel;
    
    [Header("Sliders")] 
    [SerializeField] private Slider musicVolume;
    [SerializeField] private Slider sfxVolume;
    
    [Header("Events")] 
    [SerializeField] private PlayerHealth player;


    private bool _isPaused;
    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        settingsBackButton.onClick.AddListener(OnSettingsBackButtonClicked);
        backToMainMenuButton.onClick.AddListener(OnBackToMainMenuButtonClicked);
        
        musicVolume.onValueChanged.AddListener(SetMusicVolume);
        sfxVolume.onValueChanged.AddListener(SetSFXVolume);
        
        player.PlayerDeath += GameOver;
    }

    private void Start()
    {
        IsGamePaused(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        UpdateAudioVolume();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandleUI();
        }
    }
    
    private void OnDestroy()
    {
        playButton.onClick.RemoveListener(OnPlayButtonClicked);
        exitButton.onClick.RemoveListener(OnExitButtonClicked);
        settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
        settingsBackButton.onClick.RemoveListener(OnSettingsBackButtonClicked);
        backToMainMenuButton.onClick.RemoveListener(OnBackToMainMenuButtonClicked);

        
        musicVolume.onValueChanged.RemoveListener(SetMusicVolume);
        sfxVolume.onValueChanged.RemoveListener(SetSFXVolume);
        
        player.PlayerDeath -= GameOver;

    }
    
    private void OnPlayButtonClicked()
    {
        HandleUI();
    }

    private void OnExitButtonClicked()
    {
        Debug.Log("exit");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    private void OnSettingsButtonClicked()
    {
        settingsPanel.SetActive(!settingsPanel.activeInHierarchy);
        pausePanel.SetActive(false);
    }
    private void OnSettingsBackButtonClicked()
    {
        pausePanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
    public void SetMusicVolume(float value)
    {
        AudioManager.Instance.MusicVolume(value);
    }
    public void SetSFXVolume(float value)
    {
        AudioManager.Instance.SfxVolume(value);
    }

    private void UpdateAudioVolume()
    {
        musicVolume.value = AudioManager.Instance.GetMusicVolume();
        sfxVolume.value = AudioManager.Instance.GetSFXVolume();
    }

    private void HandleUI()
    {
        if (!pausePanel.activeSelf)
        {
            IsGamePaused(true);
            
            mainPanel.SetActive(true);
            pausePanel.SetActive(true);
            settingsPanel.SetActive(false);
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
        }
        else
        {
            mainPanel.SetActive(false);
            pausePanel.SetActive(false);
            settingsPanel.SetActive(false);
            
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            
            IsGamePaused(false);
        }
    }

    private void OnBackToMainMenuButtonClicked()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void GameOver()
    {
        IsGamePaused(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        mainPanel.SetActive(true);
        losePanel.SetActive(true);
    }

    private void IsGamePaused(bool value)
    {
        if (value)
        {
            Time.timeScale = 0;
            IsPaused?.Invoke(value);
        }
        else
        {
            Time.timeScale = 1;
            IsPaused?.Invoke(value);
        }
    }
}
