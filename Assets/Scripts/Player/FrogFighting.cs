using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FrogFighting : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackDelay;

    private bool _isFighting = false;

    private WaitForSeconds _wait;
    private Coroutine _fightingCoroutine;
    private FrogHealing _healAbility;

    public float Health { get; private set; }

    private void Awake()
    {
        Health = _maxHealth;
        _wait = new WaitForSeconds(_attackDelay);
        _healAbility = GetComponent<FrogHealing>();
    }

    private void FixedUpdate()
    {
        Debug.Log($"«доровье л€гушки: {Health}");
    }

    private void OnEnable()
    {
        _healAbility.OnHealing += Heal;
    }

    private void OnDisable()
    {
        _healAbility.OnHealing -= Heal;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out EnemyFighting enemy))
        {
            _isFighting = true;
            _fightingCoroutine = StartCoroutine(Attack(enemy));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out EnemyFighting enemy))
        {
            _isFighting = false;

            if (_fightingCoroutine != null)
                StopCoroutine(_fightingCoroutine);
        }    
    }

    public void TakeDamage(float damage)
    {
        if (Health >= damage)
            Health -= damage;
        else
            SceneManager.LoadScene("SampleScene");
    }

    private IEnumerator Attack(EnemyFighting enemy)
    {
        while (_isFighting)
        {
            enemy.TakeDamage(_damage);

            yield return _wait;
        }
    }

    private void Heal(float healSize)
    {
        if (_maxHealth - Health >= healSize)
            Health += healSize;
        else
            Health = _maxHealth;
    }
}
