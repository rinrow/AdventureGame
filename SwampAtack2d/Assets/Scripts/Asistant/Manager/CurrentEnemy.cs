using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentEnemy : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private List<Enemy> _enemies;

    private static Enemy _currentEnemy;
    private int _currentEnemyNum = 0;

    private void OnEnable()
    {
        _spawner.EnemySpawned += AddEnemy;
    }

    private void OnDisable()
    {
        _spawner.EnemySpawned -= AddEnemy;
    }

    private void AddEnemy(Enemy enemy)
    {
        _enemies.Add(enemy);

        if (_currentEnemy == null)
            NextEnemy();

        enemy.Dying += CurrentEnemyDied;
    }

    private void NextEnemy()
    {
        if (_enemies.Count - 1 < _currentEnemyNum)
            return;

        _currentEnemy = _enemies[_currentEnemyNum];

        _currentEnemyNum++;
    }

    public static Enemy GetCurrentEnemy()
    {
        return _currentEnemy;
    }

    private void CurrentEnemyDied(Enemy enemy)
    {
        enemy.Dying -= CurrentEnemyDied;
        NextEnemy();
    }
}
