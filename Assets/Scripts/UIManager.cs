using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [Header("Buttons")] 
    [SerializeField] private Button playButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button settingsBackButton;
    [SerializeField] private Button creditsBackButton;

    [Header("Panels")] 
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject buttonsPanel;
    
    [Header("Sliders")] 
    [SerializeField] private Slider musicVolume;
    [SerializeField] private Slider sfxVolume;

    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        creditsButton.onClick.AddListener(OnCreditsButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        settingsBackButton.onClick.AddListener(OnSettingsBackButtonClicked);
        creditsBackButton.onClick.AddListener(OnCreditsBackButtonClicked);
    }


    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    private void OnPlayButtonClicked()
    {
        Debug.Log("play");
    }
    private void OnCreditsButtonClicked()
    {
        creditsPanel.SetActive(!creditsPanel.activeInHierarchy);
        buttonsPanel.SetActive(false);
    }
    private void OnExitButtonClicked()
    {
        Debug.Log("exit");
        Application.Quit();
    }
    private void OnSettingsButtonClicked()
    {
        settingsPanel.SetActive(!settingsPanel.activeInHierarchy);
        buttonsPanel.SetActive(false);
    }
    private void OnSettingsBackButtonClicked()
    {
        buttonsPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
    private void OnCreditsBackButtonClicked()
    {
        buttonsPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
    private void OnSoundEffectsButtonClicked()
    {
        AudioManager.Instance.PlayEffect("Player Shot");
    }
    public void SetMusicVolume()
    {
        Debug.Log("SetMusicVolume");
    }
    public void SetSFXVolume()
    {
        Debug.Log("SetSFXVolume");
    }
}
