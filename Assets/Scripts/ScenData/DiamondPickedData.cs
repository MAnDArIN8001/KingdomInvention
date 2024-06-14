using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class DiamondPickedData : MonoBehaviour
{
    [SerializeField] private Observable<int> _diamondsCount = new Observable<int>();

    private PlayerPicker _playerPicker;

    public int DiamondsCount => _diamondsCount.Value;

    public event Action<int> OnDiamondsCountChanged 
    {
        add => _diamondsCount.OnValueChanged += value;
        remove => _diamondsCount.OnValueChanged -= value;
    }

    [Inject]
    private void Initialize(PlayerPicker picker)
    {
        _playerPicker = picker;
    }

    public void OnEnable()
    {
        _playerPicker.OnPickedDiamond += HandleDiamondCountChanged;
    }

    public void OnDisable()
    {
        _playerPicker.OnPickedDiamond -= HandleDiamondCountChanged;
    }

    private void HandleDiamondCountChanged(int diamondPrice)
    {
        if (diamondPrice <= 0)
        {
            throw new Exception("diamond price must be greater then zero");
        }

        _diamondsCount.Value = _diamondsCount.Value + diamondPrice;
    }
}
