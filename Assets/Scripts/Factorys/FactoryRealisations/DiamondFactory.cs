using UnityEngine;
using Zenject;

public class DiamondFactory : IDiamondFactory
{
    private readonly DiContainer _container;

    private readonly GameObject _crystalPrefab;

    public DiamondFactory(DiContainer container, GameObject crystalPrefab)
    {
        _container = container;
        _crystalPrefab = crystalPrefab;
    }

    public Diamond Create(Vector2 position, Quaternion rotation) {
        GameObject prefab = _container.InstantiatePrefab(_crystalPrefab, position, rotation, null);

        return prefab.GetComponent<Diamond>();
    }
}
