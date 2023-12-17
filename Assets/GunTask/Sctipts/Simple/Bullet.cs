using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(CircleCollider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private CircleCollider2D _collider;

    [SerializeField] private float _maxLiveTime;
    private float _timer;


    public void SetSpeed(float speed)
    {
        _rigidbody.velocity = transform.up * speed;
    }

    public float Radius() => _collider.radius;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _maxLiveTime)
            Destroy(gameObject);
    }
}
