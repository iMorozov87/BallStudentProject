using UnityEngine;

[RequireComponent(typeof(Coin))]
public class CoinDeactivator : MonoBehaviour
{
    private Coin _coin;

    private void Awake()
    {
        _coin = GetComponent<Coin>();
    }

    private void OnEnable()
    {
        _coin.Collected += OnCoinCollected;
    }

    private void OnDisable()
    {
        _coin.Collected -= OnCoinCollected;
    }

    private void OnCoinCollected()
    {
        _coin.gameObject.SetActive(false);
    }
}
