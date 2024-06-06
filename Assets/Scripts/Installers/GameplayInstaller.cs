using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<MainInput>().FromNew().AsSingle();
        Container.Bind<DiamondPickEvent>().FromResources(ProjectConsts.DiamondPickEventPath).AsSingle();
        Container.Bind<HeartPickEvent>().FromResources(ProjectConsts.HeartPickEventPath).AsSingle();
    }
}
