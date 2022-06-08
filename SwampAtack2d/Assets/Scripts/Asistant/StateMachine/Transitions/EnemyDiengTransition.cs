using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDiengTransition : AsistantTransition
{
    void Update()
    {
        Enemy currentEnemy = CurrentEnemy.GetCurrentEnemy();

        if (currentEnemy == null)
            return;

        if (currentEnemy.IsDied)
            NeedTransit = true;
    }
}
