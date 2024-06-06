using UnityEngine;
using Zenject;

public class BoxLoot : MonoBehaviour
{
    private IDiamondFactory _diamondFactory;

    private BoxHealth _health;

    [Inject]
    private void Initialize(IDiamondFactory factory)
    {
        _diamondFactory = factory;
    }

    private void Awake()
    {
        _health = GetComponent<BoxHealth>();
    }

    private void OnEnable()
    {
        _health.OnDied += GenerateRandomLoot;
    }

    private void OnDisable()
    {
        _health.OnDied -= GenerateRandomLoot;
    }

    private void GenerateRandomLoot()
    {
        _diamondFactory.Create(transform.position, Quaternion.identity);
    }
}
