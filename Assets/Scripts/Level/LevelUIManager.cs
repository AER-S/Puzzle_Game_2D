using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIManager : MonoBehaviour
{
    [SerializeField] private GameObject GamePausedPanel;

    private void OnEnable()
    {
        LevelManager.PauseGame += ShowGamePausedPanel;
        LevelManager.UnpauseGame += HideGamePausePanel;
    }

    private void OnDisable()
    {
        LevelManager.PauseGame -= ShowGamePausedPanel;
        LevelManager.UnpauseGame -= HideGamePausePanel;
    }

    private void Start()
    {
        HideGamePausePanel();
    }

    private void ShowGamePausedPanel(LevelManager _level)
    {
        GamePausedPanel.SetActive(true);
    }

    private void HideGamePausePanel()
    {
        GamePausedPanel.SetActive(false);
    }
}
