using UnityEngine;
using System;

public class AidKit : MonoBehaviour
{
    [SerializeField] private float _minKitSize;
    [SerializeField] private float _maxKitSize;

    public event Action<AidKit> Heal;

    public float HealSize { get; private set; }

    private void Awake()
    {
        HealSize = UnityEngine.Random.Range(_minKitSize,_maxKitSize);
    }

    public void Activate() =>
        SetActivity(true);

    public void Deactivate() =>
        SetActivity(false);

    internal void Release() =>
        Heal?.Invoke(this);

    private void SetActivity(bool value) =>
        gameObject.SetActive(value);
}
