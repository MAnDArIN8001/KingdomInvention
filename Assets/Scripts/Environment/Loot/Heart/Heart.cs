using System;
using UnityEngine;
using Zenject;

public class Heart : MonoBehaviour, IPickable
{
    public event Action OnHeartPicked;

    [SerializeField] private float _healCount;

    public void PickUp(GameObject context)
    {
        OnHeartPicked?.Invoke();

        if (context.TryGetComponent<IHealable>(out var healable))
        {
            healable.Heal(_healCount);
        }

        Destroy(gameObject);
    }
}
