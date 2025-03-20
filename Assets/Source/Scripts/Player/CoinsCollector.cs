using System;
using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    public event Action<int> OnCoinCollected; 
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            OnCoinCollected?.Invoke(coin.CoinValue);
            Destroy(other.gameObject);
        }
    }
}