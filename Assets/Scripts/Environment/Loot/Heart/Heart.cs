using System;
using UnityEngine;
using Zenject;

public class Heart : MonoBehaviour, IPickable
{
    public event Action OnHeartPicked;

    [SerializeField] private float _healCount;

    private HeartPickEvent _heartPicked;

    [Inject]
    private void Initialize(HeartPickEvent heartPicked)
    {
        _heartPicked = heartPicked;
    }

    public void PickUp(GameObject context)
    {
        OnHeartPicked?.Invoke();
        _heartPicked.InvokeHeartPick();

        if (context.TryGetComponent<IHealable>(out var healable))
        {
            healable.Heal(_healCount);
        }

        Destroy(gameObject);
    }
}
