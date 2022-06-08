using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private int _currentWaveNum = 0;
    private float _timeAfterLastWave;
    private int _spawned;
    private int _enemyesCount;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChanged;
    public event Action<Enemy> EnemySpawned;

    private void Start()
    {
        SetWave(_currentWaveNum);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastWave += Time.deltaTime;

        if (_timeAfterLastWave >= _currentWave.Delay)
        {
            //Создание врагов
            InstantiateEnemy();
            _timeAfterLastWave = 0;
            _spawned++;

            EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
        }

        if (_spawned >= _currentWave.Count)
        {
            if (_waves.Count > _currentWaveNum + 1)
                AllEnemySpawned?.Invoke();

            _currentWave = null;
        }
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint);
        enemy.Init(_player);
        enemy.Dying += OnEnemyDying;

        EnemySpawned?.Invoke(enemy);
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    public void NextWave()
    {
        SetWave(++_currentWaveNum);
        _spawned = 0;

        //сброс счетчика
        EnemyCountChanged?.Invoke(0, 1);
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;

        _player.AddMoney(enemy.Reward);
    }
}

[System.Serializable]
public class Wave
{
    public Enemy Template;
    public float Delay;
    public int Count;
}

