using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable, IHealable
{
    public event Action OnReciaveDamage;
    public event Action OnHealed;
    public event Action OnDied;

    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;

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

    public void Heal(float healCount)
    {
        float newHealth = _health + healCount;

        if (newHealth > _maxHealth)
        {
            newHealth = _maxHealth;
        }

        _health = newHealth;
        OnHealed?.Invoke();
    }
}
