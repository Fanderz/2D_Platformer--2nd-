using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public float Health { get; private set; }

    public event Action<float> OnHealthChange;
    public event Action<float> OnSmoothHealthChange;

    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        Health = _maxHealth;
    }

    private void FixedUpdate()
    {
        OnSmoothHealthChange?.Invoke(Health);
    }

    internal void ChangeHealth(float value)
    {
        if (Health + value <= _maxHealth)
            Health += value;
        else
            Health = _maxHealth;

        OnHealthChange?.Invoke(Health);
    }
}
