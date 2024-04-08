using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour, ICharacter
{
    private int _hp;
    public int _maxHP;
    private AIDestinationSetter _aiDestinationSetter;
    private Player _playerRef;
    
    // Intended to be pooled so preset values in Start and Enemy reset in Awake
    private void Start()
    {
        _aiDestinationSetter = GetComponent<AIDestinationSetter>();
        _playerRef = FindObjectOfType<Player>();
        _aiDestinationSetter.target = _playerRef.transform;
    }

    private void Awake()
    {
        _hp = _maxHP;
    }

    public void TakeDamage(int damageToTake)
    {
        _hp -= damageToTake;
        if (_hp <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ICharacter>().TakeDamage(1);
        }
    }

    private void Die()
    {
        _playerRef.IncreaseScore(1);
        gameObject.SetActive(false);
    }
}