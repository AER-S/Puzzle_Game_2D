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
    }

    private void OnDisable()
    {
        PlayerMovement.FirstMove -= StartTimer;
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
                count = false;
                TimeIsUp.Invoke();
            }
        }
        
    }
    

    void StartTimer() => count = true;
    public float GetLeftTime() => timeCounter;
}
