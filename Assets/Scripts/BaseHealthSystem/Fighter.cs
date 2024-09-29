using System;
using System.Collections;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackDelay;

    private bool _isFighting = false;

    private WaitForSeconds _wait;
    private Coroutine _fightingCoroutine;

    public event Action<float> TakingDamage;

    private void Awake()
    {
        _wait = new WaitForSeconds(_attackDelay);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Fighter enemy))
        {
            _isFighting = true;
            _fightingCoroutine = StartCoroutine(Attack(enemy));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Fighter enemy))
        {
            _isFighting = false;

            if (_fightingCoroutine != null)
                StopCoroutine(_fightingCoroutine);
        }
    }

    private void TakeDamage(float damage) =>
        TakingDamage?.Invoke(damage);

    private IEnumerator Attack(Fighter enemy)
    {
        while (_isFighting)
        {
            enemy.TakeDamage(_damage);

            yield return _wait;
        }
    }
}
