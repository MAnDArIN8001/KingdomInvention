using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Vector2 _playerSpawnPoint;

    [SerializeField] private Quaternion _playerRotation;

    [SerializeField] private GameObject _playerPrefab;

    public override void InstallBindings()
    {
        var playerInstance = Container.InstantiatePrefab(_playerPrefab, _playerSpawnPoint, _playerRotation, null);

        Container.BindInstance(_playerPrefab).NonLazy();
        Container.Bind<PlayerHealth>().FromInstance(playerInstance.GetComponent<PlayerHealth>());
        Container.Bind<PlayerPicker>().FromInstance(playerInstance.GetComponent<PlayerPicker>());
    }
}
