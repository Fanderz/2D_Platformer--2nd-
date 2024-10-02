using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Fighter _fighter;

    private float _lastPosition;

    private void Awake()
    {
        _fighter.TakingDamage += _health.DecreaseHealth;
    }

    internal void Rotate(float direction)
    {
        if (direction < _lastPosition)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, -180, 0);

        _lastPosition = direction;
    }
}
