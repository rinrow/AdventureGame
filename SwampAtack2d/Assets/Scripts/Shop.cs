using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private Transform _itemContainer;
    [SerializeField] private WeaponView _template;

    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            AddItem(_weapons[i]);
        }
    }

    private void AddItem(Weapon weapon)
    {
        var view = Instantiate(_template, _itemContainer);

        view.SellButtonClicked += OnButtonClick;

        view.Render(weapon);
    }

    private void OnButtonClick(Weapon weapon, WeaponView weaponView)
    {
        TrySellItem(weapon, weaponView);
    }

    private void TrySellItem(Weapon weapon, WeaponView weaponView)
    {
        if (weapon.Price <= _player.Money)
        {
            _player.BuyItem(weapon);

            weapon.Buy();

            weaponView.SellButtonClicked -= OnButtonClick;
        }
    }

}
