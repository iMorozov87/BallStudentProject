using UnityEngine;

public class BoxAttacker : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        TryAttack(other);
    }
  
    private void TryAttack(Collider collision)
    {
        if(collision.TryGetComponent<Ball>(out Ball ball))
        {            
            ball.TakeDamage(_damage);
        }
    }

    private void OnValidate()
    {
        int minDamage = 1;
        if(_damage < minDamage)
        {
            _damage = minDamage;
        }
    }
}
