using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public event Action OnBombDeployed;

    [SerializeField] private float _damage;
    [SerializeField] private float _timeToDeploy;
    [SerializeField] private float _damageRange;

    private void Start()
    {
        StartCoroutine(DeployBomb());
    }

    private void Deploy()
    {
        var damagables = GetDemagableCollidersInRange();

        foreach (var damagable in damagables)
        {
            damagable.ReciaveHit(_damage);
        }

        Destroy(gameObject);
    }

    private IDamagable[] GetDemagableCollidersInRange()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _damageRange);

        return colliders
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

        RaycastHit2D[] hitInfo = Physics2D.RaycastAll(transform.position, directionToCollider, _damageRange);

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

    private IEnumerator DeployBomb()
    {
        yield return new WaitForSeconds(_timeToDeploy);

        OnBombDeployed?.Invoke();
        Deploy();
        Destroy(gameObject);
    }
}
