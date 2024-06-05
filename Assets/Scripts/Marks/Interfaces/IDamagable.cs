using System;
using UnityEngine;

public interface IDamagable
{
    public event Action OnReciaveDamage;
    public event Action OnDied;

    public void ReciaveHit(float damage);
}
