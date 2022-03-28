using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public event UnityAction Collected;

    public void Collect()
    {
        Collected?.Invoke();
    }
}
