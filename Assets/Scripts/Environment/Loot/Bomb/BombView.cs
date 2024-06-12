using UnityEngine;

[RequireComponent(typeof(Bomb))]
public class BombView : MonoBehaviour
{
    private Bomb _bomb;

    [SerializeField] private GameObject _deployParticles;

    private void Awake()
    {
        _bomb = GetComponent<Bomb>();
    }

    private void OnEnable()
    {
        _bomb.OnBombDeployed += CreateDeployParticles;
    }

    private void OnDisable()
    {
        _bomb.OnBombDeployed -= CreateDeployParticles;
    }

    private void CreateDeployParticles()
    {
        Instantiate(_deployParticles, transform.position, Quaternion.identity);
    }
}
