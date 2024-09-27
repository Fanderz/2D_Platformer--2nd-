using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private HealthSystem _health;

    private void Awake()
    {
        _health.OnHealthChange += ChangeHealthView;
    }

    private void ChangeHealthView(float value)
    {
        _slider.value = value / _health.MaxHealth;
    }
}
