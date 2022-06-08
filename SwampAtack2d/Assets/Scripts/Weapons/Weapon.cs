using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private bool _isBuyed;
    [SerializeField] private Sprite _icon;

    [SerializeField] protected Projectile Projectile;

    public string Label { get => _label;}
    public Sprite Icon { get => _icon;}
    public int Price { get => _price;}
    public bool IsBuyed { get => _isBuyed;}

    public abstract void Shoot(ShootPoint shootPoint);

    public void Buy()
    {
        _isBuyed = true;
    }

    protected void InitProjectile(Projectile projectile, ShootPoint shootPoint)
    {
        projectile.Init(shootPoint.PlayerDirection);
    }
}
