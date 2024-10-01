using System;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public event Action<Fruit> Eated;

    public void Activate() =>
        SetActivity(true);

    public void Deactivate() =>
        SetActivity(false);

    internal void Release() =>
        Eated?.Invoke(this);

    private void SetActivity(bool value) =>
        gameObject.SetActive(value);
}
