using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private bool[] banners = new bool[2];
    private bool complete;
    
    public static event Action<BannerController> BannerRaisen = delegate(BannerController _bannerController) {  };
    public static event Action<BannerController> BannerLowered= delegate(BannerController _bannerController) {  };
    
    private static LevelManager instance;
    public static LevelManager Instance => instance;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }

        instance = this;
    }

    private void OnEnable()
    {
        BannerRaisen += UpdateState;
        BannerLowered += UpdateState;
    }

    private void OnDisable()
    {
        BannerRaisen -= UpdateState;
        BannerLowered -= UpdateState;
    }

    private void Start()
    {
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

    void UpdateState(BannerController _banner)
    {
        StartCoroutine(UpdateComplete());
    }

    public void RaiseBanner(BannerController _raisenBanner)
    {
        BannerRaisen.Invoke(_raisenBanner);
        banners[_raisenBanner.GetIndex()] = true;
    }

    public void LowerBanner(BannerController _loweredBanner)
    {
        BannerLowered.Invoke(_loweredBanner);
        banners[_loweredBanner.GetIndex()] = false;
    }

    IEnumerator UpdateComplete()
    {
        yield return new WaitForSeconds(0.05f);
        if (banners[0] && banners[1]) complete = true;
        else complete = false;
    }
    
    
}
