using System;
using UnityEngine;

public class Healer : MonoBehaviour
{
    public event Action<float> OnHealing;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out AidKit kit))
            OnHealing?.Invoke(kit.HealSize);
    }
}
