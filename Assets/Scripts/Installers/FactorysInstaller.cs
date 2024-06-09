using Factory;
using UnityEngine;
using Zenject;

public class FactorysInstaller : MonoInstaller
{
    [SerializeField] private GameObject _diamondPrefab;
    [SerializeField] private GameObject _heartPrefab;

    public override void InstallBindings()
    {
        FactoryOfFactorys factoryOfFactories = new FactoryOfFactorys();

        Container.BindInstance(_diamondPrefab);
        Container.Bind<Factory.IFactory<Diamond>>().To<DiamondFactory>().AsTransient().WithArguments(Container, _diamondPrefab);
        Container.Bind<IGenericFactory>().To<DiamondFactory>().AsTransient().WithArguments(Container);

        Container.BindInstance(_heartPrefab);
        Container.Bind<Factory.IFactory<Heart>>().To<HeartFactory>().AsTransient().WithArguments(Container, _heartPrefab);
        Container.Bind<IGenericFactory>().To<HeartFactory>().AsTransient().WithArguments(Container);

        IGenericFactory diamondFacotory = Container.Resolve<Factory.IFactory<Diamond>>() as IGenericFactory;
        IGenericFactory heartFactory = Container.Resolve<Factory.IFactory<Heart>>() as IGenericFactory;

        factoryOfFactories.RegisterFactory(LootTypes.Diamond, diamondFacotory);
        factoryOfFactories.RegisterFactory(LootTypes.Heart, heartFactory);

        Container.BindInstance(factoryOfFactories).AsSingle();
    }
}
