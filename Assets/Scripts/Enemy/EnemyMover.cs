using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _movementSpeed;

    private float _xScale;
    private float _xStartPosition;
    private Vector3 _velocity;

    private Coroutine _coroutine;

    private void Awake()
    {
        _xScale = transform.localScale.x;
        _xStartPosition = transform.position.x;
    }

    private void Start()
    {
        _coroutine = StartCoroutine(Move());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<Frog>() != null && _coroutine != null)
        {
                StopCoroutine(_coroutine);
                _coroutine = null;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<Frog>() != null)
            transform.position = Vector2.Lerp(transform.position, new Vector2(collision.transform.position.x,transform.position.y), _movementSpeed / 2 * Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<Frog>() != null && _coroutine == null && gameObject != null)
                _coroutine = StartCoroutine(Move());
    }

    private void Rotate(float direction)
    {
        if (direction != 0)
            transform.localScale = new Vector3(direction * _xScale, transform.localScale.y, transform.localScale.z);
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

            Rotate(-_velocity.x);
            transform.position += _velocity * Time.deltaTime;

            yield return null;
        }
    }
}
