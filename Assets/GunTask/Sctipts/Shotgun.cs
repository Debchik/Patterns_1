using System.Collections;
using UnityEngine;

public class Shotgun : MonoBehaviour, IShootable
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform[] _shotPoints;

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
        Debug.Log(_canShoot);
        if (_canShoot)
        {
            Bullet bullet;
            for (int i = 0; i < _shotPoints.Length; ++i)
            {
                
                if (_bulletCount > 0)
                {
                    _bulletCount--;
                    bullet = Instantiate(_bullet, _shotPoints[i]);
                    bullet.SetSpeed(_bulletSpeed);
                }
                else
                    break;
            }

            _canShoot = false;
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
            yield return new WaitForSeconds(_shortReloadTime);
            _canShoot = true;
        }

        
    }
}
