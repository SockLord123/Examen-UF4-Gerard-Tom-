using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    public void Oncollected()
    {
        GameManager.gameManager.CoinCollected();
        Destroy(gameObject);
    }
}
