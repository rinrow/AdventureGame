using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Asistant : MonoBehaviour, IDamagable, IHealthable
{
    [SerializeField] private Player _player;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private int _currentHealth;
    private List<Enemy> _enemies;
    private Animator _animator;

    public List<Enemy> Enemies => _enemies;
    public Player Player => _player;
    public float Speed => _speed;
    public int Damage => _damage;
    public bool IsDied { get;  set; } = false;

    public int CurrentHealth => _currentHealth;

    public event Action<int, int> HealthChanged;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _currentHealth = _health;
    }


    public void ApplyDamage(int damage)
    {
        print("Asistant attacked");

        _currentHealth -= damage;

        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
        {
            print("Asistant died");

            IsDied = true;
        }
    }
}
