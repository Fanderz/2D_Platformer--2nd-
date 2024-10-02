using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _movementSpeed;

    private Enemy _enemy;
    private float _xStartPosition;
    private Vector3 _velocity;

    private Coroutine _coroutine;

    private void Awake()
    {
        _xStartPosition = transform.position.x;
        _enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        _coroutine = StartCoroutine(Move());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Frog>() != null && _coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Frog>() != null)
            transform.position = Vector2.Lerp(transform.position, new Vector2(collision.transform.position.x, transform.position.y), _movementSpeed * Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Frog>() != null && _coroutine == null && gameObject != null)
            _coroutine = StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        _velocity = Vector3.left * _movementSpeed;

        while (gameObject.activeSelf)
        {
            if (transform.position.x >= _xStartPosition + _distance)
                _velocity.x = -_movementSpeed;
            else if (transform.position.x <= _xStartPosition - _distance)
                _velocity.x = _movementSpeed;

            _enemy.Rotate(transform.position.x);
            transform.position += _velocity * Time.deltaTime;

            yield return null;
        }
    }
}
