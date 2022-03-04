using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int index;
    
    private bool[] banners = new bool[2];
    private bool complete;
    private bool pause;

    private InputManager controls;
    
    public static event Action<BannerController> BannerRisen = delegate(BannerController _bannerController) {  };
    public static event Action<BannerController> BannerLowered= delegate(BannerController _bannerController) {  };
    
    public static event Action LevelComplete = delegate {  };
    
    public static event Action PauseGame = delegate {  };
    public static event Action UnpauseGame = delegate {  }; 
    
    private static LevelManager instance;
    public static LevelManager Instance => instance;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }

        instance = this;
        controls = new InputManager();
        controls.Player.Pause.performed += a => TogglePause();
    }

    public void TogglePause()
    {
        pause = !pause;
        if(pause)PauseGame.Invoke();
        else UnpauseGame.Invoke();
    }

    private void OnEnable()
    {
        BannerRisen += UpdateState;
        BannerLowered += UpdateState;
        //LevelComplete += StunGame;
        LevelTimer.TimeIsUp += FailLevel;
        PauseGame += StunGame;
        UnpauseGame += UnStunGame;
        controls.Enable();
    }

    private void OnDisable()
    {
        if(controls!=null) controls.Disable();
        BannerRisen -= UpdateState;
        BannerLowered -= UpdateState;
        //LevelComplete -= StunGame;
        LevelTimer.TimeIsUp -= FailLevel;
        PauseGame -= StunGame;
        UnpauseGame -= UnStunGame;
    }

    private void Start()
    {
        UnStunGame();
        pause = false;
        complete = false;
        ResetBanners();
    }

    void ResetBanners()
    {
        for (int i = 0; i < 2; i++)
        {
            banners[i] = false;
        }
    }

    void StunGame()
    {
        Time.timeScale = 0;
    }

    void UnStunGame()
    {
        Time.timeScale = 1;
    }

    void FailLevel()
    {
        StunGame();
    }

    void UpdateState(BannerController _banner)
    {
        StartCoroutine(UpdateComplete());
    }

    public void RaiseBanner(BannerController _raisenBanner)
    {
        BannerRisen.Invoke(_raisenBanner);
        banners[_raisenBanner.GetIndex()] = true;
    }

    public void LowerBanner(BannerController _loweredBanner)
    {
        BannerLowered.Invoke(_loweredBanner);
        banners[_loweredBanner.GetIndex()] = false;
    }

    public int GetIndex() => index;

    IEnumerator UpdateComplete()
    {
        yield return new WaitForSeconds(0.05f);
        if (banners[0] && banners[1])
        {
            LevelComplete.Invoke();
            complete = true;
        }
        else complete = false;
    }
    
    
}
