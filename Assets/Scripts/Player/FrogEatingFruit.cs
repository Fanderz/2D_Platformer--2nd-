using UnityEngine;
using System;

public class FrogEatingFruit : MonoBehaviour
{
    public event Action Eated;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Fruit fruit))
        {
            Eated?.Invoke();
            fruit.Release();
        }    
    }
}
