using System;
using TMPro;
using UnityEngine;

public class TextHealthBar : BaseHealthBar
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        ChangeHealthView(health.Health);
    }

    public override void ChangeHealthView(float value)
    {
        _text.text = $"{(int)Math.Ceiling(value)}/{health.MaxHealth}";
    }
}
