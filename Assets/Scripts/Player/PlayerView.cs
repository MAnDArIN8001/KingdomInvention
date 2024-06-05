using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private string _moveDirectionKey;
    [SerializeField] private string _jumpKey;
    [SerializeField] private string _attackKey;
    [SerializeField] private string _hitKey;
    [SerializeField] private string _isAliveKey;

    private Animator _animator;

    private PlayerMover _mover;
    private PlayerHealth _health;
    private PlayerAttack _attack;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _health = GetComponent<PlayerHealth>();
        _attack = GetComponent<PlayerAttack>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _mover.OnMoveDirectionCompute += ComputeWalkDirectionAnimation;
        _mover.OnGroundCompute += ComputeJumpAnimation;

        _health.OnReciaveDamage += TriggerHitAnimation;
        _health.OnDied += ComputeDeathAnimation;

        _attack.OnMadeAttack += TriggerAttackAnimation;
    }

    private void OnDisable()
    {
        _mover.OnMoveDirectionCompute -= ComputeWalkDirectionAnimation;
        _mover.OnGroundCompute -= ComputeJumpAnimation;

        _health.OnReciaveDamage += TriggerHitAnimation;
        _health.OnDied += ComputeDeathAnimation;

        _attack.OnMadeAttack -= TriggerAttackAnimation;
    }

    private void ComputeWalkDirectionAnimation(Vector2 direction) => _animator.SetFloat(_moveDirectionKey, Mathf.Abs(direction.x));

    private void ComputeJumpAnimation(bool onGround) => _animator.SetBool(_jumpKey, onGround);

    private void TriggerHitAnimation() => _animator.SetTrigger(_hitKey);

    private void ComputeDeathAnimation() => _animator.SetBool(_isAliveKey, false);

    private void TriggerAttackAnimation() => _animator.SetTrigger(_attackKey);
}
