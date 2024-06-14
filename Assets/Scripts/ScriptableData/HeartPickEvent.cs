using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "heartEvent", menuName = "Events/New HeartEvent")]
public class HeartPickEvent : ScriptableObject
{
    public UnityEvent OnDiamondPicked;

    public void InvokeHeartPick() => OnDiamondPicked?.Invoke();
}
