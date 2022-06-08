using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDieTransition : EnemyTransition
{
    private CollideTransition _collideTransition;
    private IDamagable _target;

    private void Awake()
    {
        _collideTransition = GetComponent<CollideTransition>();
    }

    private void OnEnable()
    {
        NeedTransit = false;
        _target = _collideTransition.Damagable;
    }

    private void Update()
    {
        if (_target.IsDied || _target == null)
            NeedTransit = true;
    }
}
