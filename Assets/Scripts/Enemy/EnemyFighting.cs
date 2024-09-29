using UnityEngine;

public class EnemyFighting : MonoBehaviour
{
    [SerializeField] private HealthSystem _health;
    [SerializeField] private Fighter _fighter;

    private void Awake()
    {
        _fighter.TakingDamage += _health.DecreaseHealth;
    }

    private void FixedUpdate()
    {
        //Debug.Log($"Здоровье Бота: {_health.Health}");
    }
}
