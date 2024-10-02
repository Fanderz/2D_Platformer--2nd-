using UnityEngine;

public class FrogMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _jumpForce = 5f;

    private Frog _frog;
    private FrogRotation _rotation;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _frog = GetComponent<Frog>();
        _rotation = GetComponentInChildren<FrogRotation>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _frog.OnFrogMove += Move;
        _frog.OnFrogJump += Jump;
    }

    private void OnDisable()
    {
        _frog.OnFrogMove -= Move;
        _frog.OnFrogJump -= Jump;
    }

    private void Move(float direction)
    {
        if (direction != 0f)
        {
            transform.Translate(_moveSpeed * direction * Time.deltaTime * Vector2.right);
            _rotation.Rotate(direction);
        }
    }

    private void Jump()
    {
        _rigidbody.AddForce(new Vector2(0, _jumpForce),ForceMode2D.Impulse);
    }
}
