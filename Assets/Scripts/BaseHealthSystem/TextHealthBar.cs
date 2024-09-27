using System;
using TMPro;
using UnityEngine;

public class TextHealthBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private HealthSystem _health;

    private void Awake()
    {
        _health.OnHealthChange += ChangeTextHealthView;
    }

    private void Start()
    {
        ChangeTextHealthView(_health.Health);
    }

    private void ChangeTextHealthView(float value)
    {
        _text.text = $"{(int)Math.Ceiling(value)}/{_health.MaxHealth}";
    }
}
