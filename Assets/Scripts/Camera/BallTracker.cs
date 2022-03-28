using UnityEngine;

public class BallTracker : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Vector3 _positionOffset;

    private void LateUpdate()
    {
        transform.position = _ball.transform.position + _positionOffset;
    }
}
