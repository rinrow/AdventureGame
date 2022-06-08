using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttackState))]
public class HeroDistanceTransition : EnemyTransition
{
    [SerializeField] private float _notAttackDistance;

    private Transform _targetTransform;
    private CollideTransition _collideTransition;

    private void Awake()
    {
        _collideTransition = GetComponent<CollideTransition>();
    }

    private void OnEnable()
    {
        NeedTransit = false;
        _targetTransform = _collideTransition.CollidedObject.transform;
    }

    private void Update()
    {
        if (_targetTransform == null)
            return;

        _targetTransform = _collideTransition.CollidedObject.transform;
        print("_targetTransform = " + _targetTransform.position);

        if (Vector3.Distance(_targetTransform.position, transform.position) >= _notAttackDistance)
        {
            print("HeroDistanceTransition");
            NeedTransit = true;
        }
    }
}
