using UnityEngine;

public class BoxLoot : MonoBehaviour
{
    [SerializeField] private GameObject[] _lootVariants;

    private BoxHealth _health;

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
        int randomIndex = Random.Range(0, _lootVariants.Length);

        Instantiate(_lootVariants[randomIndex], transform.position, Quaternion.identity);
    }
}
