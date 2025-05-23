using UnityEngine;

public class EnemyExample : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    private EnemyHandler _enemyHandler;

    private void Awake()
    {
        _enemyHandler = new EnemyHandler(5, 10);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Enemy enemy = CreateEnemy();
            _enemyHandler.AddEnemy(enemy, () => enemy.IsDead);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Enemy enemy = CreateEnemy();
            _enemyHandler.AddEnemy(enemy, () => enemy.Lifetime >= _enemyHandler.MaxEnemyLifetime);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Enemy enemy = CreateEnemy();
            _enemyHandler.AddEnemy(enemy, () => _enemyHandler.EnemiesCount > _enemyHandler.MaxEnemiesCapacity);
        }

        _enemyHandler.HandleEnemies();
    }

    private Enemy CreateEnemy()
    {
        float randomX = Random.Range(-8, 8);
        float randomZ = Random.Range(-8, 8);
        Vector3 randomPosition = new Vector3(randomX, 0, randomZ);

        return Instantiate(_enemyPrefab, randomPosition, Quaternion.identity);
    }
}
