using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPosition : MonoBehaviour
{
    [SerializeField] private AttackState _attackState;
    [Range(0, 1.5f)]
    [SerializeField] private float _distanceRange;

    private void Start()
    {
        _attackState = GetComponent<AttackState>();
    }

    private void OnEnable()
    {
        _attackState.AttackPositionAchieved += SetAttackPosition;
    }

    private void OnDisable()
    {
        _attackState.AttackPositionAchieved -= SetAttackPosition;
    }

    private void SetAttackPosition()
    {
        Transform attackTransform = _attackState.transform;

        Vector3 pos = attackTransform.position;
        pos.x = pos.x + Random.Range(-_distanceRange, _distanceRange);
        attackTransform.position = pos;
    }
}
