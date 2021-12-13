using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIManager : MonoBehaviour
{
    [SerializeField] private GameObject GamePausedPanel;
    [SerializeField] private GameObject GameLostPanel;
    [SerializeField] private GameObject GameWonPanel;
    private void OnEnable()
    {
        LevelManager.PauseGame += ShowGamePausedPanel;
        LevelManager.UnpauseGame += HideGamePausePanel;
        LevelTimer.TimeIsUp += ShowGameLostPanel;
        LevelManager.LevelComplete += ShowGameWonPanel;
    }

    private void OnDisable()
    {
        LevelManager.PauseGame -= ShowGamePausedPanel;
        LevelManager.UnpauseGame -= HideGamePausePanel;
        LevelTimer.TimeIsUp -= ShowGameLostPanel;
        LevelManager.LevelComplete -= ShowGameWonPanel;
    }

    private void Start()
    {
        HideGamePausePanel();
        HideGameLostPanel();
        HideGameWonPanel();
    }

    private void ShowGamePausedPanel() => GamePausedPanel.SetActive(true);
    private void HideGamePausePanel() => GamePausedPanel.SetActive(false);
    private void ShowGameLostPanel() => GameLostPanel.SetActive(true);
    private void HideGameLostPanel() => GameLostPanel.SetActive(false);
    private void ShowGameWonPanel() => GameWonPanel.SetActive(true);
    private void HideGameWonPanel() => GameWonPanel.SetActive(false);
}
