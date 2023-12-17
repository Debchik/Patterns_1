using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private BulletCount _bulletCount;
    [SerializeField] private Transform _gunPosition;

    private IShootable _shootable;

    public Transform GunPosition => _gunPosition;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && _shootable != null)
        {
            _shootable.Shoot();
            _bulletCount.UpdateText(_shootable.BulletsLeft());
        }
    }

    public void EquipGun(IShootable shootable)
    {
        _shootable?.Unequip();

        _shootable = shootable;
        _bulletCount.UpdateText(_shootable.BulletsLeft());
    }
}
