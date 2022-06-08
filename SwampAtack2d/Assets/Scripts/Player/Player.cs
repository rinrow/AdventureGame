using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour, IDamagable, IHealthable
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private ShootPoint _shootPoint;
    [SerializeField] private int _currentWeaponIndex = 0;
    [SerializeField] private int _money;

    private int _currentHealth;
    private Weapon _currentWeapon;
    private Animator _animator;

    public int Money { get => _money; }
    public Weapon CurrentWeapon => _currentWeapon;

    public bool IsDied { get; set; }

    public event Action<int, int> HealthChanged;
    public event Action<int> MoneyChanged;
    public event Action<Weapon> WeaponChanged; 

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _currentHealth = _health;

        ChangeWeapon(_weapons[_currentWeaponIndex]);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    public void BuyItem(Weapon weapon)
    {
        _money -= weapon.Price;

        _weapons.Add(weapon);

        MoneyChanged?.Invoke(Money);
    }

    public void ApplyDamage(int damage)
    {
        print("Player attacked");

        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    public void AddMoney(int reward)
    {
        _money += reward;

        MoneyChanged?.Invoke(Money);
    }

    public void NextWeapon()
    {
        if (_currentWeaponIndex < _weapons.Count - 1)
        {
            _currentWeaponIndex++;
        }
        else if (_currentWeaponIndex == _weapons.Count - 1)
        {
            _currentWeaponIndex = 0;
        }

        ChangeWeapon(_weapons[_currentWeaponIndex]);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        WeaponChanged?.Invoke(weapon);

        _currentWeapon = weapon;
    }
}
