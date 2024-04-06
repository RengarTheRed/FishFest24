using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Info")] 
    [SerializeField] private List<Vector2> _spawnPoints;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _poolSize;
    [SerializeField] private float _spawnTimer;

    private float _currentTimer = 0;
    private ObjectPool _enemyPool;

    private void Awake()
    {
        _currentTimer = _spawnTimer;
        PoolInfo enemyPoolInfo = new PoolInfo(transform, _enemyPrefab, _poolSize);
        _enemyPool = new ObjectPool(enemyPoolInfo);
    }

    private void Update()
    {
        _currentTimer -= Time.deltaTime;
        
        // If Timer expire Spawn and Reset Timer
        if (_currentTimer < 0)
        {
            SpawnEnemy();
            _currentTimer = _spawnTimer;
        }
    }

    private void SpawnEnemy()
    {
        GameObject toSpawn = _enemyPool.GetObjectFromPool();
        toSpawn.transform.position = Vector2.zero;
        toSpawn.SetActive(true);
    }
}
