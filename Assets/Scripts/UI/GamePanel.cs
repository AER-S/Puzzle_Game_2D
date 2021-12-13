using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class GamePanel : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;
    private void OnEnable()
    {
        restartButton.onClick.AddListener(RestartLevel);
        exitButton.onClick.AddListener(QuitLevel);
        AddOtherListeners();
        UpdatePanel();
    }

    private void OnDisable()
    {
        restartButton.onClick.RemoveListener(RestartLevel);
        exitButton.onClick.RemoveListener(QuitLevel);
        RemoveOtherListeners();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void QuitLevel()
    {
        SceneManager.LoadScene(0);
    }

    protected abstract void UpdatePanel();
    protected abstract void AddOtherListeners();
    protected abstract void RemoveOtherListeners();
}
