using System;
using UnityEngine;

public class BoxHealth : MonoBehaviour, IDamagable
{
    public event Action OnReciaveDamage;
    public event Action OnDied;

    [SerializeField] private float _health;

    public void ReciaveHit(float damage)
    {
        float newHealth = _health - damage;

        if (newHealth <= 0)
        {
            newHealth = 0;

            OnDied?.Invoke();
        }

        _health = newHealth;

        OnReciaveDamage?.Invoke();
    }
}
