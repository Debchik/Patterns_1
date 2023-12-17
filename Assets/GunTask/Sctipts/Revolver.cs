using System.Collections;
using UnityEngine;

public class Revolver : MonoBehaviour, IShootable
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shotPoint;
    
    [SerializeField, Range(1, 16)] private int _maxBulletCount;

    [SerializeField, Range(0.1f, 100f)] private float _bulletSpeed;
    [SerializeField, Range(0f, 10f)] private float _shortReloadTime;
    [SerializeField, Range(0f, 20f)] private float _longReloadTime;


    private int _bulletCount = 0;
    private bool _canShoot = true;

    private void Awake()
    {
        _bulletCount = _maxBulletCount;
    }

    private void OnValidate()
    {
        if (_longReloadTime < _shortReloadTime)
            _longReloadTime = _shortReloadTime;
    }


    public void Shoot()
    {
        if (_canShoot && _bulletCount > 0)
        {
            _bulletCount--;
            _canShoot = false;
            Bullet bulletObject = Instantiate(_bullet, _shotPoint);
            bulletObject.SetSpeed(_bulletSpeed);

            Reload();
        }
    }

    public string BulletsLeft() => _bulletCount.ToString();

    public void Reload() => StartCoroutine(ReloadProcess());

    public void Unequip() => Destroy(gameObject);


    private IEnumerator ReloadProcess()
    {
        if (_bulletCount <= 0)
        {
            yield return new WaitForSeconds(_longReloadTime);
            _bulletCount = _maxBulletCount;
            _canShoot = true;
        }
        else
        {
            Debug.Log("StartReloading");
            yield return new WaitForSeconds(_shortReloadTime);
            Debug.Log("FinishReloading");
            _canShoot = true;
        }
    }

    
}
