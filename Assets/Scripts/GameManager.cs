using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public int orbs = 0, Coins = 0;


    private void Awake()
    {
        if(GameManager.gameManager != null &&   GameManager.gameManager !=this)
            Destroy(gameManager);
        else
        {
            GameManager.gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void OrbCollected()
    {
        orbs++;
    }

    public void CoinCollected()
    {
        Coins++;
    }
}

