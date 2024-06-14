using UnityEngine;
using Zenject;

public class LevelDataInstaller : MonoInstaller
{
    [SerializeField] private DiamondPickedData _crystalPickedData;

    public override void InstallBindings()
    {
        var crystalPickedData = Container.InstantiatePrefabForComponent<DiamondPickedData>(_crystalPickedData, transform.position, Quaternion.identity, transform);

        Container.Bind<DiamondPickedData>().FromInstance(crystalPickedData).AsSingle().NonLazy();
    }
}
