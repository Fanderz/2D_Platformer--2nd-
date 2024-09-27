using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBarView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private HealthSystem _health;
    [SerializeField] private float _changeRate;

    private void Awake()
    {
        _health.OnSmoothHealthChange += ChangeHealthView;
    }

    private void ChangeHealthView(float value)
    {
        _slider.value = Mathf.MoveTowards(_slider.value, value / _health.MaxHealth, _changeRate * Time.deltaTime);
    }
}
