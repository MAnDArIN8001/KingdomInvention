using System;
using UnityEngine;
using Zenject;

public class Diamond : MonoBehaviour, IPickable
{
    public event Action OnDiamondPicked;

    [SerializeField] private DiamondPickEvent _diamondPicked;

    [Inject]
    private void Initialize(DiamondPickEvent diamondPicked)
    {
        _diamondPicked = diamondPicked;
    }

    public void PickUp(MonoBehaviour sender)
    {
        OnDiamondPicked?.Invoke();
        _diamondPicked.InvokeDiamondPick();

        Destroy(gameObject);
    }
}
