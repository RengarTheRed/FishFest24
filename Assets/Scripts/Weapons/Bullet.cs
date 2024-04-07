using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public String TagToHit;

    private float maxLifeTime = 10;
    private float lifeTimer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(TagToHit))
        {
            other.GetComponent<ICharacter>().TakeDamage(10);
            Debug.Log("Hit target");
        }

        if (other.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }

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