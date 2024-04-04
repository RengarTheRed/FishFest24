using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICharacter
{
    private int _hp;
    public int _maxHP;
    
    
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