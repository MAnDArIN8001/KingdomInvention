using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private List<Image> _healhImages;

    private PlayerHealth _playerHealth;

    [Inject]
    private void Initialize(PlayerHealth playerHealth)
    {
        _playerHealth = playerHealth;
    }

    private void OnEnable()
    {
        _playerHealth.OnReciaveDamage += HandleHitReciaving;
        _playerHealth.OnHealed += HandleHealing;
    }

    private void OnDisable()
    {
        _playerHealth.OnReciaveDamage += HandleHitReciaving;
        _playerHealth.OnHealed += HandleHealing;
    }

    private void HandleHitReciaving()
    {
        for (int i = _healhImages.Count-1; i >= 0; i--)
        {
            if (_healhImages[i].IsActive())
            {
                _healhImages[i].gameObject.SetActive(false);

                break;
            }
        } 
    }

    private void HandleHealing()
    {
        foreach (var item in _healhImages)
        {
            if (!item.IsActive())
            {
                item.gameObject.SetActive(true);

                break;
            }
        } 
    }
}
