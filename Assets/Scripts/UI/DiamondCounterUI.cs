using Zenject;
using UnityEngine;
using TMPro;

public class DiamondCounterUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;

    private DiamondPickedData _pickData;

    [Inject]
    private void Initialize(DiamondPickedData pickData)
    {
        _pickData = pickData;
    }

    private void OnEnable()
    {
        _pickData.OnDiamondsCountChanged += DiamondPickedHandler;
    }

    private void OnDisable()
    {
        _pickData.OnDiamondsCountChanged -= DiamondPickedHandler;
    }

    private void DiamondPickedHandler(int diamondCounts)
    {
        _counterText.text = diamondCounts.ToString();
    }
}
