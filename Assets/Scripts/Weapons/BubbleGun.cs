using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGun : MonoBehaviour
{
    [Header("Fire Rate")]
    public float bulletsPerSecond=2;
    private float fireTimer, currentFireTimer;

    [Header("Bullet Settings")] 
    [SerializeField] private GameObject bulletPrefab;
    

    private ObjectPool _bubblePool;

    // Calculate how often to fire to achieve the Bullet Per Second set and start timer
    private void Awake()
    {
        fireTimer = 1 / bulletsPerSecond;
        currentFireTimer = fireTimer;
        Debug.Log(fireTimer);

        PoolInfo _bubbleInfo = new PoolInfo(null, bulletPrefab, 5);
        _bubblePool = new ObjectPool(_bubbleInfo);
    }

    private void Update()
    {
        fireTimer -= Time.deltaTime;
        if (fireTimer < 0)
        {
            FireGun();
            currentFireTimer = fireTimer;
        }
    }

    private void FireGun()
    {
        Debug.Log("Bang!");
        
        GameObject bullet = _bubblePool.GetObjectFromPool();
        bullet.transform.position = transform.right + transform.position;
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.right*5);
    }
}
