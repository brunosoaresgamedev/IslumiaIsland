﻿  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            GameManager.instance.coin++;
            
          
            Destroy(gameObject);
        }
    }

}
