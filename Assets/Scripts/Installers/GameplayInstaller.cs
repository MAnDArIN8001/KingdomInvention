using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<MainInput>().FromNew().AsSingle();
        Container.Bind<DiamondPickEvent>().FromNew().AsSingle();
    }
}
