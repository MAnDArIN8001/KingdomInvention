using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    public event Action<Vector2> OnMoveDirectionCompute;
    public event Action<bool> OnGroundCompute;

    private bool _isRight;
    [SerializeField] private bool _onGround;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;

    private MainInput _input;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _isRight = transform.localScale.x > 0;
    }

    [Inject]
    private void Construct(MainInput input)
    {
        _input = input;
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.Player.Jump.performed += HandleJumpClick;
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        Vector2 direction = ReadInputValue();

        OnMoveDirectionCompute?.Invoke(direction);

        if (direction.x != 0)
        {
            Move(direction.x);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Groundable>(out Groundable ground))
        {
            _onGround = true;
            OnGroundCompute?.Invoke(_onGround);
        }
    }

    private void HandleJumpClick(InputAction.CallbackContext context)
    {
        if (!_onGround)
        {
            return;
        }

        Jump();
        OnGroundCompute?.Invoke(_onGround);
    }

    private void Move(float direction)
    {
        Vector2 newVelocity = new Vector2(direction * _speed, _rigidbody.velocity.y);

        _rigidbody.velocity = newVelocity;

        if ((direction > 0 && !_isRight) || (direction < 0 && _isRight))
        {
            Flip();

            _isRight = !_isRight;
        }
    }

    private void Jump()
    {
        Vector2 newVelocity = new Vector2(_rigidbody.velocity.x, _jumpForce);

        _onGround = false;

        _rigidbody.velocity = newVelocity;
    }

    private void Flip()
    {
        Vector3 newScale = new Vector3() { 
            x = -transform.localScale.x,
            y = transform.localScale.y,
            z = transform.localScale.z
        };

        transform.localScale = newScale;
    }

    private Vector2 ReadInputValue() => _input.Player.Movement.ReadValue<Vector2>().normalized;
}
