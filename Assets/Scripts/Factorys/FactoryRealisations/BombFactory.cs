using UnityEngine;
using Zenject;

public class BombFactory : Factory.IFactory<Bomb>, IGenericFactory
{
    private DiContainer _container;

    private GameObject _bombPrefab;

    public BombFactory(DiContainer container, GameObject bombPrefab)
    {
        _container = container;
        _bombPrefab = bombPrefab;
    }

    public Bomb Create(Vector2 position, Quaternion rotation)
    {
        GameObject prefab = _container.InstantiatePrefab(_bombPrefab, position, rotation, null);

        return prefab.GetComponent<Bomb>();
    }

    IPickable IGenericFactory.Create(Vector2 position, Quaternion rotation)
    {
        throw new System.NotImplementedException();
    }
}
