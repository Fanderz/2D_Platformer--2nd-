using UnityEngine;

public class BaseHealthBar : MonoBehaviour
{
    [SerializeField] protected HealthSystem health;

    private void Awake()
    {
        health.HealthChanged += ChangeHealthView;
    }

    public virtual void ChangeHealthView(float value)
    {
    }
}
