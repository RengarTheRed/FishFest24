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


    private float time = 5;

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
        time = 5;
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Die();
            time = 5;
        }
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
        _playerRef.IncreaseScore(1);
        Debug.Log("I have blubbed my last");
        gameObject.SetActive(false);
    }
}