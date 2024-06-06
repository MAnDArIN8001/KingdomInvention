using UnityEngine;
using Zenject;

public class FactorysInstaller : MonoInstaller
{
    [SerializeField] private GameObject _crystalPrefab;

    public override void InstallBindings()
    {
        Container.BindInstance(_crystalPrefab).AsSingle();
        Container.Bind<IDiamondFactory>().To<DiamondFactory>().AsSingle();
    }
}
