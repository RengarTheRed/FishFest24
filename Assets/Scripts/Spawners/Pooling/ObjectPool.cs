using System.Collections.Generic;
using UnityEngine;
using System.Linq;

class ObjectPool
{
    private PoolInfo _poolInfo;
    private List<GameObject> _objPool;
    
    
    public ObjectPool(PoolInfo inInfo)
    {
        _poolInfo = inInfo;
        _objPool = new List<GameObject>();
        for (int i = 0; i < _poolInfo.InitialPoolSize; i++)
        {
            CreateObjectInPool();
        }
    }

    private GameObject CreateObjectInPool()
    {
        GameObject newPoolObject = Object.Instantiate(_poolInfo.ObjPrefab, Vector2.zero, Quaternion.identity);
        newPoolObject.transform.parent = _poolInfo.ParentObject;
        newPoolObject.SetActive(false);
        _objPool.Add(newPoolObject);
        
        return newPoolObject;
    }

    public GameObject GetObjectFromPool()
    {
        foreach (var t in _objPool.Where(t => !t.activeSelf))
        {
            return t;
        }
        return CreateObjectInPool();
    }
}

// Struct to group variables
public struct PoolInfo
{
    public PoolInfo(Transform parentTransform, GameObject prefab, int poolSize)
    {
        ParentObject = parentTransform;
        ObjPrefab = prefab;
        InitialPoolSize = poolSize;
    }
    public Transform ParentObject;
    public GameObject ObjPrefab;
    public int InitialPoolSize;
}