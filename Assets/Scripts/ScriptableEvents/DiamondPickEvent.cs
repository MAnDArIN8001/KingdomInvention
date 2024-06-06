using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "DiamondEvent", menuName = "Events/New DiamonEvent")]
public class DiamondPickEvent : ScriptableObject
{
    public UnityEvent OnDiamondPicked;

    public void InvokeDiamondPick() => OnDiamondPicked?.Invoke();
}
