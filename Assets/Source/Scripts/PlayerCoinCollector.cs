using UnityEngine;

public class PlayerCoinCollector : MonoBehaviour
{
    private int _coinsCollected;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            _coinsCollected++;
            
            Debug.Log("Монеток собрано: " + _coinsCollected);
            
            Destroy(other.gameObject);
        }
    }
}