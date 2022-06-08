using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyState : AsistantState
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDelay;

    private float _timeAfterLastAttack;

    private void Update()
    {
        if (Enemy == null)
            return;

        Animator.Play("Attack");

        _timeAfterLastAttack += Time.deltaTime;

        if(_timeAfterLastAttack >= _attackDelay)
        {
            _timeAfterLastAttack = 0;
            Attack(_damage);
        }
    }

    private void Attack(int damage)
    {
        print("AttackEnemy");
        CurrentEnemy.GetCurrentEnemy().ApplyDamage(damage);
    }
}
