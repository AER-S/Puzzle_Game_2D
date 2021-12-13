using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameLostPanel : GamePanel
{
    [SerializeField] private TextMeshProUGUI levelIndex;
    protected override void UpdatePanel()
    {
        levelIndex.text = LevelManager.Instance.GetIndex().ToString("00");
    }

    protected override void AddOtherListeners() {}
    protected override void RemoveOtherListeners() {}
}
