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
        if (!CheckIfPoolExist(_poolInfo.ObjPrefab))
        {
            for (int i = 0; i < _poolInfo.InitialPoolSize; i++)
            {
                CreateObjectInPool();
            }
        }
    }

    private bool CheckIfPoolExist(GameObject prefabToCheck)
    {
        if (GameObject.Find(prefabToCheck.name + " parent"))
        {
            GameObject existingPool = GameObject.Find(prefabToCheck.name + " parent");
            foreach (Transform poolObj in existingPool.transform)
            {
                _objPool.Add(poolObj.gameObject);
            }
            return true;
        }
        return false;
    }

    private GameObject CreateObjectInPool()
    {
        GameObject newPoolObject = Object.Instantiate(_poolInfo.ObjPrefab, Vector2.zero, Quaternion.identity);
        newPoolObject.SetActive(false);

        if (!_poolInfo.ParentObject)
        {
            _poolInfo.ParentObject = new GameObject(_poolInfo.ObjPrefab.name + " parent").transform;
        }
        newPoolObject.transform.parent = _poolInfo.ParentObject;
        
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