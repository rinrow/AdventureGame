using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamagable, IHealthable
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private Player _target;

    private int _currentHealth;

    public Player Target => _target;

    public int Reward => _reward;

    public bool IsDied { get; set; }

    public UnityAction<Enemy> Dying;

    public event Action<int, int> HealthChanged;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void Init(Player target)
    {
        _target = target;
    }
    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
        {
            Dying?.Invoke(this);
            IsDied = true;
        }
    }
}
