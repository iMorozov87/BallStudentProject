using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private CoinCollector _coinCollector;
    [SerializeField] private TMP_Text _moneyCountText; 

    private void OnEnable()
    {
        _coinCollector.Collected += OnCoinCollected;
    }

    private void OnDisable()
    {
        _coinCollector.Collected -= OnCoinCollected;
    }

    private void OnCoinCollected(uint coinCount)
    {
        _moneyCountText.text = coinCount.ToString();
    }
}
