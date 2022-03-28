using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [Range(1, 10), SerializeField] private int _health = 1;
    [SerializeField] private BallMover _ballMover;

    public event UnityAction Died;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _ballMover.ResetState();
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
