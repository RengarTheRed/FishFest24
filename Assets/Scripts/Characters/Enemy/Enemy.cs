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
    private Transform _playerRef;
    private void Awake()
    {
        _aiDestinationSetter = GetComponent<AIDestinationSetter>();
        _playerRef = FindObjectOfType<PlayerMovement>().transform;
        _aiDestinationSetter.target = _playerRef;
    }

    public void TakeDamage(int damageToTake)
    {
        _hp = -damageToTake;
        if (_hp < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("I have blubbed my last");
    }
}