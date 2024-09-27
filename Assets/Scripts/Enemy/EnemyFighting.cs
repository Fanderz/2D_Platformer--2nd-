using UnityEngine;

public class EnemyFighting : MonoBehaviour
{
    [SerializeField] private HealthSystem _health;
    [SerializeField] private Fighter _fighter;

    private void Awake()
    {
        _fighter.OnChangeHealth += _health.ChangeHealth;
    }

    private void FixedUpdate()
    {
        //Debug.Log($"Здоровье Бота: {_health.Health}");

        if (_health.Health <= 0)
            Destroy(gameObject);
    }
}
