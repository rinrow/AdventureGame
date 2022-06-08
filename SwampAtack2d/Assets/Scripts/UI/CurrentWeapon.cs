using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentWeapon : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _currentWeaponImage;

    private void OnEnable()
    {
        _player.WeaponChanged += ChangeCurrentWeaponImage;
    }

    private void OnDisable()
    {
        _player.WeaponChanged -= ChangeCurrentWeaponImage;
    }

    [ContextMenu("ChangeSprite")]
    private void ChangeCurrentWeaponImage(Weapon weapon)
    {
        _currentWeaponImage.sprite = weapon.Icon;
    }
}
