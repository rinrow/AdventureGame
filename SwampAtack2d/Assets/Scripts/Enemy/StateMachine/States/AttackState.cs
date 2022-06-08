using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private Animator _animator;
    private CollideTransition _collideTransition;
    private Collider2D _targetCollider;
    private IDamagable _target;
    private float _lastAttackTime;

    public event Action AttackPositionAchieved;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collideTransition = GetComponent<CollideTransition>();
    }

    private void OnEnable()
    {
        _target = _collideTransition.Damagable;
        _targetCollider = _collideTransition.Collision;

        AttackPositionAchieved?.Invoke();
    }

    private void OnDisable()
    {
        _target = null;
        _targetCollider = null;
    }

    private void Update()
    {
        if (_target != null && _targetCollider != null)
            Attack(_targetCollider, _target);
    }

    private void Attack(Collider2D collision, IDamagable damagable)
    {
        _animator.Play("Attack");

        if (_lastAttackTime <= 0)
        {
            damagable.ApplyDamage(_damage);

            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }
}
