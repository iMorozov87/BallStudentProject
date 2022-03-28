using UnityEngine;
using UnityEngine.Events;

public class CoinCollector : MonoBehaviour
{
    private uint _coinsCount = 0;

    public event UnityAction<uint> Collected;

    private void Start()
    {
        Collected?.Invoke(_coinsCount);
    }

    private void OnTriggerEnter(Collider collider)
    {
        TryCollectCoins(collider);
    }

    private void TryCollectCoins(Collider collider)
    {
        if(collider.TryGetComponent<Coin>(out Coin coin))
        {
            coin.Collect();
            _coinsCount++;
            Collected?.Invoke(_coinsCount);
        }
    }
}
