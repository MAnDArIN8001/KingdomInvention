using UnityEngine;
using Zenject;
using Factory;

public class BoxLoot : MonoBehaviour
{
    [SerializeField] private LootTypes[] _lootTypes;

    private FactoryOfFactorys _factoryOfFactorys;

    private BoxHealth _health;

    [Inject]
    private void Initialize(FactoryOfFactorys factoryOfFactorys)
    {
        _factoryOfFactorys = factoryOfFactorys;
    }

    private void Awake()
    {
        _health = GetComponent<BoxHealth>();
    }

    private void OnEnable()
    {
        _health.OnDied += GenerateRandomLoot;
    }

    private void OnDisable()
    {
        _health.OnDied -= GenerateRandomLoot;
    }

    private void GenerateRandomLoot()
    {
        int randomIndex = UnityEngine.Random.Range(0, _lootTypes.Length);

        IGenericFactory factory = _factoryOfFactorys.GetFactory(_lootTypes[randomIndex]);

        factory.Create(transform.position, Quaternion.identity);
    }
}
