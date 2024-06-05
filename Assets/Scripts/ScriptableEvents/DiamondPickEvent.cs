using UnityEngine;
using UnityEngine.Events;

public class DiamondPickEvent
{
    public UnityEvent OnDiamondPicked;

    public void InvokeDiamondPick() => OnDiamondPicked?.Invoke();
}
