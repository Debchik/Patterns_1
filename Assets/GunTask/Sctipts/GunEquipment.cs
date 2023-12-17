using UnityEngine;

public class GunEquipment : MonoBehaviour
{
    [SerializeField] private PlayerGun _playerGun;

    [SerializeField] private Revolver _revolver;
    [SerializeField] private SVG _svg;
    [SerializeField] private Shotgun _shotgun;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            IShootable revolver = Instantiate(_revolver, _playerGun.GunPosition);
            _playerGun.EquipGun(revolver);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            IShootable SVG = Instantiate(_svg, _playerGun.GunPosition);
            _playerGun.EquipGun(SVG);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            IShootable shotgun = Instantiate(_shotgun, _playerGun.GunPosition);
            _playerGun.EquipGun(shotgun);
        }
    }
}
