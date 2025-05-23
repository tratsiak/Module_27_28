using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler
{
    private Dictionary<Enemy, Func<bool>> _enemies = new Dictionary<Enemy, Func<bool>>();

    public EnemyHandler(int maxEnemiesCapacity, float maxEnemyLifetime)
    {
        MaxEnemiesCapacity = maxEnemiesCapacity;
        MaxEnemyLifetime = maxEnemyLifetime;
    }

    public int MaxEnemiesCapacity { get; private set; }

    public float MaxEnemyLifetime { get; private set; }

    public int EnemiesCount => _enemies.Count;

    public void HandleEnemies()
    {
        List<Enemy> enemiesToRemove = new List<Enemy>();

        foreach (var keyValuePair in _enemies)
            if (keyValuePair.Value())
                enemiesToRemove.Add(keyValuePair.Key);

        foreach (Enemy enemy in enemiesToRemove)
        {
            _enemies.Remove(enemy);
            UnityEngine.Object.Destroy(enemy.gameObject);
        }

        ShowEnemiesCount();
    }

    public void AddEnemy(Enemy enemy, Func<bool> condition) => _enemies.Add(enemy, condition);

    private void ShowEnemiesCount() => Debug.Log(_enemies.Count);
}
