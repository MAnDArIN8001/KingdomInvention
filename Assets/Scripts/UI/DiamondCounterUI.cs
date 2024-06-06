using Zenject;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiamondCounterUI : MonoBehaviour
{
    private int _currentDiamondCount;

    [SerializeField] private TMP_Text _counterText;

    private DiamondPickEvent _pickEvent;

    [Inject]
    private void Initialize(DiamondPickEvent pickEvent)
    {
        _pickEvent = pickEvent;
    }

    private void OnEnable()
    {
        _pickEvent.OnDiamondPicked.AddListener(OnDiamondPickedHandler);
    }

    private void OnDisable()
    {
        _pickEvent.OnDiamondPicked.RemoveListener(OnDiamondPickedHandler);
    }

    private void OnDiamondPickedHandler()
    {
        _currentDiamondCount++;

        _counterText.text = _currentDiamondCount.ToString();
    }
}
