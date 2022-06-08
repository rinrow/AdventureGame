using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyDistanceTransition : AsistantTransition
{
    [SerializeField] private float _transitDistance;

    private void Update()
    {
        Enemy enemy = CurrentEnemy.GetCurrentEnemy();

        if (enemy == null || enemy.IsDied)
            return;

        if (Vector2.Distance(Player.transform.position, enemy.transform.position) <= _transitDistance)
            NeedTransit = true;
    }
}
