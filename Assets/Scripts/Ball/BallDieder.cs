using UnityEngine;

public class BallDieder : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private ParticleSystem _diedEffect;

    private void OnEnable()
    {
        _ball.Died += OnBallDied;
    }

    private void OnDisable()
    {
        _ball.Died -= OnBallDied;
    }

    private void OnBallDied()
    {
        Instantiate(_diedEffect, transform.position, Quaternion.identity);
        _ball.gameObject.SetActive(false);
    }
}
