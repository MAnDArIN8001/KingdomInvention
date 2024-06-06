using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "playerModel", menuName = "Gameplay/New PlayerModel")]
public class DiamondPickEvent : ScriptableObject
{
    public UnityEvent OnDiamondPicked;

    public void InvokeDiamondPick() => OnDiamondPicked?.Invoke();
}
