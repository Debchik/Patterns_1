using System.Collections;
using UnityEngine;

public class SVG : MonoBehaviour, IShootable
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shotPoint;

    [SerializeField, Range(0.1f, 100f)] private float _bulletSpeed;
    [SerializeField, Range(0f, 10f)] private float _reloadTime;

    private bool _canShoot;

    private const string InfinityBullets = "inf";

    private void Awake()
    {
        _canShoot = true;
    }

    public void Shoot()
    {
        if (_canShoot)
        {
            Bullet bulletObject = Instantiate(_bullet, _shotPoint);
            bulletObject.SetSpeed(_bulletSpeed);

            _canShoot = false;
            Reload();
        }
    }

    public string BulletsLeft() => InfinityBullets;

    public void Reload() => StartCoroutine(ReloadProcess());

    public void Unequip() => Destroy(gameObject);

    private IEnumerator ReloadProcess()
    {
        yield return new WaitForSeconds(_reloadTime);

        _canShoot = true;
    }
}
