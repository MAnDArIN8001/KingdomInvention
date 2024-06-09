using UnityEngine;
using Zenject;

public class DiamondFactory : Factory.IFactory<Diamond>, IGenericFactory
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

    IPickable IGenericFactory.Create(Vector2 position, Quaternion rotation) => Create(position, rotation);
}
