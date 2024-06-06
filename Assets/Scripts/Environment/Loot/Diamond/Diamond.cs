using System;
using UnityEngine;
using Zenject;

public class Diamond : MonoBehaviour, IPickable
{
    public event Action OnDiamondPicked;

    private DiamondPickEvent _diamondPicked;

    [Inject]
    private void Initialize(DiamondPickEvent diamondPicked)
    {
        _diamondPicked = diamondPicked;
        Debug.Log(diamondPicked);
    }

    public void PickUp(GameObject sender)
    {
        OnDiamondPicked?.Invoke();
        _diamondPicked.InvokeDiamondPick();

        Destroy(gameObject);
    }
}
