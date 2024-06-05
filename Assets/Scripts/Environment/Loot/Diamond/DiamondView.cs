using UnityEngine;

public class DiamondView : MonoBehaviour
{
    [SerializeField] private GameObject _destructionEffect;

    private Diamond _diamond;

    private void Awake()
    {
        _diamond = GetComponent<Diamond>();
    }

    private void OnEnable()
    {
        _diamond.OnDiamondPicked += CreateDestructionEffect;
    }

    private void OnDisable()
    {
        _diamond.OnDiamondPicked += CreateDestructionEffect;
    }

    private void CreateDestructionEffect()
    {
        Instantiate(_destructionEffect, transform.position, Quaternion.identity);
    }
}
