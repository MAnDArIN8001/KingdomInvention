using System;
using UnityEngine;

public class PlayerPicker : MonoBehaviour
{
    public event Action<int> OnPickedDiamond;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IPickable>(out var pickable))
        {
            pickable.PickUp(gameObject);

            if (pickable is Diamond)
            {
                var diamond = pickable as Diamond;

                int diamondPrice = diamond.DiamondPrice;

                OnPickedDiamond?.Invoke(diamondPrice);
            }
        }
    }
}
