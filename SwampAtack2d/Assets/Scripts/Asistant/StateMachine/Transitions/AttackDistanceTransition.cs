using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDistanceTransition : AsistantTransition
{
    [SerializeField] private float _attackDistance;

    private void Update()
    {
        Enemy currentEnemy = CurrentEnemy.GetCurrentEnemy();

        if (currentEnemy == null || currentEnemy.IsDied)
            return;

        if (Vector3.Distance(transform.position, currentEnemy.transform.position) <= _attackDistance)
            NeedTransit = true;
    }
}
