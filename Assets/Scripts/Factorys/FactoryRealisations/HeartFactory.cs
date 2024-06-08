using UnityEngine;
using Zenject;

public class HeartFactory : IHeartFactory
{
    private readonly DiContainer _container;

    private readonly GameObject _heartPrefab;

    public HeartFactory(DiContainer container, GameObject crystalPrefab)
    {
        _container = container;
        _heartPrefab = crystalPrefab;
    }

    public Heart Create(Vector2 position, Quaternion rotation)
    {
        GameObject prefab = _container.InstantiatePrefab(_heartPrefab, position, rotation, null);

        return prefab.GetComponent<Heart>();
    }
}