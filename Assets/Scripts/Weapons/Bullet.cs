using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public String TagToHit;

    private float maxLifeTime = 10;
    private float lifeTimer;

    private bool _bulletUsed=false;
    

    private void OnEnable()
    {
        _bulletUsed = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Bullet de-spawn on either hitting tagged target or wall
        if (!_bulletUsed)
        {
            _bulletUsed = true;
            if(other.CompareTag(TagToHit))
            {
                other.GetComponent<ICharacter>().TakeDamage(1);
                gameObject.SetActive(false);
            }
            if (other.CompareTag("Wall"))
            {
                gameObject.SetActive(false);
            }
        }
    }

    // Bullet lifespan
    private void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer < 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            lifeTimer = maxLifeTime;
            gameObject.SetActive(false);
        }
    }
}