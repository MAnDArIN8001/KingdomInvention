using System;
using UnityEngine;

public class PlayerPicker : MonoBehaviour
{
    public event Action OnPickedHeal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IPickable>(out var pickable))
        {

        }
    }
}
