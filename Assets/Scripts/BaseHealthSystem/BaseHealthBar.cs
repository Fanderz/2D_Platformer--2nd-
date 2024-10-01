using UnityEngine;

public class BaseHealthBar : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void Awake()
    {
        Health.Changed += ChangeHealthView;
    }

    private void OnDisable()
    {
        Health.Changed -= ChangeHealthView;
    }

    public virtual void ChangeHealthView(float value)
    {
    }
}
