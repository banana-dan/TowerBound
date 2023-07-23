using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private GameObject[] _stuffPrefabs;
    private BoxCollider2D _spawnArea;

    private void Awake()
    {
        _spawnArea = GetComponent<BoxCollider2D>();
    }

    public void SpawnRandomEnemy(int countOfEnemies)
    {
        for (int i = 0; i < countOfEnemies; ++i)
        {
            Bounds bounds = _spawnArea.bounds;
            int indexOfEnemy = Random.Range(0, _enemyPrefabs.Length - 1);
            float x = Random.Range(bounds.min.x, bounds.max.x);
            Instantiate(_enemyPrefabs[indexOfEnemy], new Vector3(x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }

    public void SpawnRandomStuff(int countOfStuff)
    {
        for (int i = 0; i < countOfStuff; ++i)
        {
            Bounds bounds = _spawnArea.bounds;
            int indexOfStuff = Random.Range(0, _stuffPrefabs.Length - 1);
            float x = Random.Range(bounds.min.x, bounds.max.x);
            Instantiate(_stuffPrefabs[indexOfStuff], new Vector3(x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
