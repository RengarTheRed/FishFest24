using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public String TagToHit;

    private float maxLifeTime = 2;
    private float lifeTimer;

    private void Awake()
    {
        lifeTimer = maxLifeTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(TagToHit))
        {
            other.GetComponent<ICharacter>().TakeDamage(10);
            Debug.Log("Hit target");
        }
    }

    private void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer < 0)
        {
            gameObject.SetActive(false);
        }
    }
}