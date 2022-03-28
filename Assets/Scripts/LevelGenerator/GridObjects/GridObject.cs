using UnityEngine;

public abstract class GridObject : MonoBehaviour
{
    [SerializeField] private float _size = 1f;

    public float Size => _size;

    private void OnValidate()
    {
        transform.localScale = new Vector3(_size, _size, _size);
    }
}
