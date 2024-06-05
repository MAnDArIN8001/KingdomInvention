using System;
using System.Linq;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerAttack : MonoBehaviour
{
    public event Action OnMadeAttack;

    [SerializeField] private bool _canAttack;

    [SerializeField] private float _damage;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private float _attackRadius;

    private MainInput _input;

    [SerializeField] private Transform _attackPosition;

    [Inject]
    private void Construct(MainInput input)
    {
        _input = input;
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.Player.Attack.performed += HandleAttack;
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.Player.Attack.performed -= HandleAttack;
    }

    private void HandleAttack(InputAction.CallbackContext context)
    {
        if (!_canAttack)
        {
            return;
        }

        Attack();
    }

    private void Attack()
    {
        OnMadeAttack?.Invoke();

        IDamagable[] targets = GetTargetsToHit();

        foreach (var target in targets)
        {
            target.ReciaveHit(_damage);
        }

        _canAttack = false;

        StartCoroutine(Reload());
    }

    private IDamagable[] GetTargetsToHit()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(_attackPosition.position, _attackRadius);

        return targets
            .Where(IsValidTarget)
            .Select(GetDamagable)
            .ToArray();
    }

    private IDamagable GetDamagable(Collider2D collider) => collider.GetComponent<IDamagable>();

    private bool IsValidTarget(Collider2D collider)
    {
        return collider.gameObject != gameObject 
            && IsColliderReachable(collider) 
            && collider.TryGetComponent<IDamagable>(out var damagable);
    }

    private bool IsColliderReachable(Collider2D collider)
    {
        bool isReachable = true;

        Vector2 directionToCollider = collider.transform.position - transform.position;

        RaycastHit2D[] hitInfo = Physics2D.RaycastAll(_attackPosition.position, directionToCollider, _attackRadius);

        foreach (var info in hitInfo)
        {
            if (info.collider.gameObject == gameObject)
            {
                continue;
            }
            else if (info.collider == collider)
            {
                break;
            } 
            else if (info.collider.TryGetComponent<Obstacle>(out Obstacle obstacle))
            {
                isReachable = false;

                break;
            }
        }     
        
        return isReachable;
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(_attackCooldown);

        _canAttack = true;
    }
}
