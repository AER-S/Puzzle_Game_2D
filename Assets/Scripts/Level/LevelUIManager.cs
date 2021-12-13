using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIManager : MonoBehaviour
{
    [SerializeField] private GameObject GamePausedPanel;
    [SerializeField] private GameObject GameLostPanel;
    private void OnEnable()
    {
        LevelManager.PauseGame += ShowGamePausedPanel;
        LevelManager.UnpauseGame += HideGamePausePanel;
        LevelTimer.TimeIsUp += ShowGameLostPanel;
    }

    private void OnDisable()
    {
        LevelManager.PauseGame -= ShowGamePausedPanel;
        LevelManager.UnpauseGame -= HideGamePausePanel;
        LevelTimer.TimeIsUp -= ShowGameLostPanel;
    }

    private void Start()
    {
        HideGamePausePanel();
        HideGameLostPanel();
    }

    private void ShowGamePausedPanel(LevelManager _level=null) => GamePausedPanel.SetActive(true);
    private void HideGamePausePanel() => GamePausedPanel.SetActive(false);
    private void ShowGameLostPanel() => GameLostPanel.SetActive(true);
    private void HideGameLostPanel() => GameLostPanel.SetActive(false);
}
