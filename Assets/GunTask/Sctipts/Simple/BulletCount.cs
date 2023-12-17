using UnityEngine;
using TMPro;

public class BulletCount : MonoBehaviour
{
    [SerializeField] private TMP_Text _bulletCount;

    public void UpdateText(string num)
    {
        _bulletCount.text = "Bullets left: " + num;
    }

}
