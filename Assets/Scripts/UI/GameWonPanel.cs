using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameWonPanel : GamePanel
{
    [SerializeField] private Button continueButton;
    [SerializeField] private TextMeshProUGUI levelIndex;
    protected override void UpdatePanel()
    {
        levelIndex.text = LevelManager.Instance.GetIndex().ToString("00");
    }

    void ContinueGame()
    {
        //To Implement Later
    }

    protected override void AddOtherListeners()
    {
        continueButton.onClick.AddListener(ContinueGame);
    }

    protected override void RemoveOtherListeners()
    {
        continueButton.onClick.RemoveListener(ContinueGame);
    }
}
