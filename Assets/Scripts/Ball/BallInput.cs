using UnityEngine;

[RequireComponent(typeof(BallMover))]
public class BallInput : MonoBehaviour
{
    private BallMover _mover;

    private void Awake()
    {
        _mover = GetComponent<BallMover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _mover.TryStartJump();
        }
    }

}
