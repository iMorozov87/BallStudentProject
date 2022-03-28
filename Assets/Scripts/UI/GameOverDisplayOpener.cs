using UnityEngine;

public class GameOverDisplayOpener : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private UIPanelAnimator _gameOverDisplay;

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
        _gameOverDisplay.Open();
    }
}
