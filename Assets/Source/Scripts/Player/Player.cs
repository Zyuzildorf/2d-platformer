using UnityEngine;

[RequireComponent(typeof(CoinsCollector))]
public class Player : MonoBehaviour
{
    private CoinsCollector _coinsCollector;
    private int _money;
    
    private void OnEnable()
    {
        _coinsCollector.OnCoinCollected += TakeCoin;
    }

    private void OnDisable()
    {
        _coinsCollector.OnCoinCollected -= TakeCoin;
    }

    private void TakeCoin(int coinValue)
    {
        _money += coinValue;
        
        Debug.Log("Денег в кошельке: " + _money);
    }
    
    private void Awake()
    {
        _coinsCollector = GetComponent<CoinsCollector>();
    }
}