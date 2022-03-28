using UnityEngine;
using DG.Tweening;

public class UIPanelAnimator : MonoBehaviour
{
    [SerializeField] private Transform _panel;
    [SerializeField] private Transform _closedPosition;
    [SerializeField] private Transform _openedPosition;
    [SerializeField] private Vector3 _closedScale;
    [SerializeField] private Vector3 _openedScale = Vector3.one;
    [SerializeField] private float _animationDuration = 2f;
   
    public void Open()
    {
        ChangePositionAndScale(_openedPosition.position, _openedScale);
    }

    public void Close()
    {
        ChangePositionAndScale(_closedPosition.position, _closedScale);
    }

    private void ChangePositionAndScale(Vector3 targetPosition, Vector3 targetScale)
    {
        _panel.DOMove(targetPosition, _animationDuration);
        _panel.DOScale(targetScale, _animationDuration);
    }
}
