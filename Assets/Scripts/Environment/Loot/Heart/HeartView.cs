using UnityEngine;

[RequireComponent(typeof(Heart))]
public class HeartView : MonoBehaviour
{
    private Heart _heart;

    [SerializeField] private GameObject _destructionEffect;

    private void Awake()
    {
        _heart = GetComponent<Heart>();
    }

    private void OnEnable()
    {
        _heart.OnHeartPicked += CreateDestructionEffect;
    }

    private void OnDisable()
    {
        _heart.OnHeartPicked -= CreateDestructionEffect;
    }

    private void CreateDestructionEffect() => Instantiate(_destructionEffect, transform.position, Quaternion.identity);
}
