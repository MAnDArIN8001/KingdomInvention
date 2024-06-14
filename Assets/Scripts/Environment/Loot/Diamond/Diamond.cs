using System;
using UnityEngine;

public class Diamond : MonoBehaviour, IPickable
{
    public event Action OnDiamondPicked;

    [SerializeField] private int _diamondPrice;  

    public int DiamondPrice => _diamondPrice; 

    public void PickUp(GameObject context)
    {
        OnDiamondPicked?.Invoke();

        Destroy(gameObject);
    }
}
