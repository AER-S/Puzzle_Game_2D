using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePausedPanel : GamePanel
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private TextMeshProUGUI levelIndex;
    [SerializeField] private TextMeshProUGUI leftTime;

    protected override void UpdatePanel()
    {
        levelIndex.text = LevelManager.Instance.GetIndex().ToString("00");
        leftTime.text = FindObjectOfType<LevelTimer>().GetLeftTime().ToString("00:00");
    }

    public override void AddOtherListeners()
    {
        resumeButton.onClick.AddListener(ResumeLevel);
    }

    public override void RemoveOtherListeners()
    {
        resumeButton.onClick.RemoveListener(ResumeLevel);
    }


    private void ResumeLevel()
    {
        LevelManager.Instance.TogglePause();
    }
}
