using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDyingTransition : EnemyTransition
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        NeedTransit = false;

        _enemy.Dying += OnDying;
    }

    private void OnDisable()
    {
        _enemy.Dying -= OnDying;

    }

    private void OnDying(Enemy enemy)
    {
        NeedTransit = true;
    }
}
