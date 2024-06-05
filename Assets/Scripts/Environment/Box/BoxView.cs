using UnityEngine;

public class BoxView : MonoBehaviour
{
    [SerializeField] private string _hitKey;

    [SerializeField] private GameObject[] _peaces;

    private Animator _animator;

    private BoxHealth _health;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _health = GetComponent<BoxHealth>();
    }

    private void OnEnable()
    {
        _health.OnReciaveDamage += TriggerHitAnimation;
        _health.OnDied += CreateBoxPeaces;
    }

    private void OnDisable()
    {
        _health.OnReciaveDamage -= TriggerHitAnimation;
        _health.OnDied += CreateBoxPeaces;
    }

    private void TriggerHitAnimation() => _animator.SetTrigger(_hitKey);

    private void CreateBoxPeaces()
    {
        Destroy(gameObject);

        foreach (var peace in _peaces)
        {
            Instantiate(peace, transform.position, Quaternion.identity);
        }
    }
}
