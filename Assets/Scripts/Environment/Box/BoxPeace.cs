using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BoxPeace : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _startVelocity;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        Destroy(gameObject, _lifeTime);

        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = ProjectExpansions.GetRandomDirectionVector() * _startVelocity;
    }
}
