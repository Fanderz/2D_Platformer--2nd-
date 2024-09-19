using UnityEngine;
using System.Collections;

public class EnemyFighting : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackDelay;

    private bool _isFighting;
    private WaitForSeconds _wait;

    private Coroutine _fightingCoroutine;

    public float Health { get; private set; }

    private void Awake()
    {
        Health = _maxHealth;
        _wait = new WaitForSeconds(_attackDelay);
    }

    private void FixedUpdate()
    {
        Debug.Log($"Çהמנמגüו גנאדא: {Health}");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out FrogFighting frog))
        {
            _isFighting = true;
            _fightingCoroutine = StartCoroutine(Attack(frog));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out FrogFighting frog))
        {
            _isFighting = false;
            StopCoroutine(_fightingCoroutine);
        }
    }

    public void TakeDamage(float damage)
    {
        if (Health >= _damage)
            Health -= damage;
        else
            Destroy(this.gameObject);
    }

    private IEnumerator Attack(FrogFighting frog)
    {
        while (_isFighting)
        {
            frog.TakeDamage(_damage);

            yield return _wait;
        }
    }
}
