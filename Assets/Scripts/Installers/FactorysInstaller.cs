using Factory;
using UnityEngine;
using Zenject;

public class FactorysInstaller : MonoInstaller
{
    [SerializeField] private GameObject _diamondPrefab;
    [SerializeField] private GameObject _heartPrefab;
    [SerializeField] private GameObject _bombPrefab;

    public override void InstallBindings()
    {
        FactoryOfFactorys factoryOfFactories = new FactoryOfFactorys();

        Container.BindInstance(_diamondPrefab);
        Container.Bind<Factory.IFactory<Diamond>>().To<DiamondFactory>().AsTransient().WithArguments(Container, _diamondPrefab);
        Container.Bind<IGenericFactory>().To<DiamondFactory>().AsTransient().WithArguments(Container);

        Container.BindInstance(_heartPrefab);
        Container.Bind<Factory.IFactory<Heart>>().To<HeartFactory>().AsTransient().WithArguments(Container, _heartPrefab);
        Container.Bind<IGenericFactory>().To<HeartFactory>().AsTransient().WithArguments(Container);

        Container.BindInstance(_bombPrefab);
        Container.Bind<Factory.IFactory<Bomb>>().To<BombFactory>().AsTransient().WithArguments(Container, _bombPrefab);
        Container.Bind<IGenericFactory>().To<BombFactory>().AsTransient().WithArguments(Container);

        IGenericFactory diamondFacotory = Container.Resolve<Factory.IFactory<Diamond>>() as IGenericFactory;
        IGenericFactory heartFactory = Container.Resolve<Factory.IFactory<Heart>>() as IGenericFactory;
        IGenericFactory bombFactory = Container.Resolve<Factory.IFactory<Bomb>>() as IGenericFactory;

        factoryOfFactories.RegisterFactory(LootTypes.Diamond, diamondFacotory);
        factoryOfFactories.RegisterFactory(LootTypes.Heart, heartFactory);
        factoryOfFactories.RegisterFactory(LootTypes.ActiveBomb, bombFactory);

        Container.BindInstance(factoryOfFactories).AsSingle();
    }
}
