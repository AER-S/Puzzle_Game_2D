using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerController : MonoBehaviour
{
    [SerializeField] private int index;
    private PlayerMovement player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        GetPlayer(other);
        if (player) LevelManager.Instance.RaiseBanner(this);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GetPlayer(other);
        if(player) LevelManager.Instance.LowerBanner(this);
    }

    void GetPlayer(Collider2D _other)
    {
        player = _other.GetComponent<PlayerMovement>();
    }

    public int GetIndex() => index;
}
