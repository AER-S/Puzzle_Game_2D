using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private float levelTime;

    private float timeCounter;
    private bool timeIsUp;
    private bool count;
    
    public static event Action TimeIsUp = delegate {  };

    private void OnEnable()
    {
        PlayerMovement.FirstMove += StartTimer;
        LevelManager.LevelComplete += StopTimer;
    }

    private void OnDisable()
    {
        PlayerMovement.FirstMove -= StartTimer;
        LevelManager.LevelComplete -= StopTimer;
    }

    private void Start()
    {
        timeCounter = levelTime;
        timeIsUp = false;
        count = false;
    }

    private void Update()
    {
        if (count)
        {
            if (timeCounter>0)
            {
                timeCounter -= Time.deltaTime;
                return;
            }

            if (!timeIsUp)
            {
                timeIsUp = true;
                StopTimer();
                TimeIsUp.Invoke();
            }
        }
        
    }
    

    void StartTimer() => count = true;

    void StopTimer(LevelManager _level=null) => count = false;
}
