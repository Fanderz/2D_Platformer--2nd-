using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public float Health { get; private set; }

    public event Action<float> HealthChanged;
    //public event Action<float> OnSmoothHealthChange;

    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        Health = _maxHealth;
    }

    private void FixedUpdate()
    {
        //OnSmoothHealthChange?.Invoke(Health);
    }

    internal void ChangeHealth(float value)
    {
        if (Health + value <= _maxHealth)
            Health += value;
        else
            Health = _maxHealth;

        HealthChanged?.Invoke(Health);
    }

    internal void IncreaseHealth(float value)
    {
        if (Health + value <= _maxHealth)
            Health += value;
        else
            Health = _maxHealth;

        HealthChanged?.Invoke(Health);
    }

    internal void DecreaseHealth(float value)
    {
        if (Health - value > 0)
            Health -= value;
        else
            Destroy(gameObject);

        HealthChanged?.Invoke(Health);
    }
}
