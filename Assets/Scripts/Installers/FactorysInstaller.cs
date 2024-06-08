using UnityEngine;
using Zenject;

public class FactorysInstaller : MonoInstaller
{
    [SerializeField] private GameObject _crystalPrefab;
    [SerializeField] private GameObject _heartPrefab;

    public override void InstallBindings()
    {
        Container.BindInstance(_crystalPrefab).AsSingle();
        Container.Bind<IDiamondFactory>().To<DiamondFactory>().AsSingle();

        Container.BindInstance(_crystalPrefab).AsSingle();
        Container.Bind<IHeartFactory>().To<HeartFactory>().AsSingle();
    }
}
