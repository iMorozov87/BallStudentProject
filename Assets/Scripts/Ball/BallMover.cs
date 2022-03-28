using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BallJumper))]
public class BallMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private BallJumper _jumper;
    private Rigidbody _rigidbody;
    private MoveState _state;
    private Vector3 _targetPosition;

    private void Awake()
    {
        _jumper = GetComponent<BallJumper>();
        _rigidbody = GetComponent<Rigidbody>();
        _state = MoveState.Run;
    }

    private void OnEnable()
    {
        _jumper.Finished += OnJumperFiniched;
    }

    private void OnDisable()
    {
        _jumper.Finished -= OnJumperFiniched;
    }

    private void FixedUpdate()
    {
        float positionY = GetPositionAxisY() ;     
        _targetPosition = new Vector3(_rigidbody.position.x + _speed * Time.fixedDeltaTime,
                                      positionY,
                                      _rigidbody.position.z);
        _rigidbody.MovePosition(_targetPosition);      
    }

    private float GetPositionAxisY()
    {
        if (_state == MoveState.Jump)
        {
            return _jumper.CurrentHeight;
        }        
            return _rigidbody.position.y;      
    }

    public void TryStartJump()
    {
        if (_state == MoveState.Run && _jumper.IsReady() == true)
        {
            _state = MoveState.Jump;
            _jumper.StartJump(_rigidbody.position.y);
        }
    }

    public void ResetState()
    {
        _state = MoveState.Run;
    }

    private void OnJumperFiniched()
    {
        ResetState();
    }
}

enum MoveState
{
    Run,
    Jump
}