using UnityEngine;

public class EnemyFighting : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Fighter _fighter;

    private void Awake()
    {
        _fighter.TakingDamage += _health.DecreaseHealth;
    }
}
