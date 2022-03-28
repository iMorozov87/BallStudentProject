using UnityEngine;
using UnityEngine.Events;

public class BallJumper : MonoBehaviour
{
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private float _height = 1f;
    [SerializeField] private float _duration = 3f;
    [SerializeField] private Transform _groundPoint;

    private float _elapsedTime;
    private float _currentHeight;
    private float _startHeight;    

    public float CurrentHeight => _currentHeight;

    public event UnityAction Finished;

    private void Awake()
    {
        enabled = false;
    }

    private void Update()
    {
        if(_elapsedTime >= _duration)
        {
            FinishJump();
        }
        _currentHeight = _jumpCurve.Evaluate(_elapsedTime/_duration) * _height + _startHeight;
        _elapsedTime += Time.deltaTime;
    }

    public void StartJump(float startHeight) 
    {
        _startHeight = startHeight;
        _elapsedTime = 0;
        _currentHeight = _startHeight;
        enabled = true;
    }

    public bool IsReady()
    {
        float radius = 0.1f;
        Collider[] contactColliders = Physics.OverlapSphere(_groundPoint.position, radius);
        foreach (var collider in contactColliders)
        {
            if(collider.TryGetComponent<Cell>(out Cell cell))
            {
                return true;
            }
        }
        return false;
    }

    private void FinishJump()
    {
        Finished?.Invoke();
        enabled = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float radius = 0.1f;
        Gizmos.DrawSphere(_groundPoint.position, radius);
    }
}
