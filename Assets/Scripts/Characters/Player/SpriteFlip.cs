using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlip : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRef;
    private void FixedUpdate()
    {
        RotateSprite();
    }
    // Sprite Flipping Logic
    private void RotateSprite()
    {
        if (transform.rotation.z > 0)
        {
            _spriteRef.flipY = true;
        }

        if (transform.rotation.z < 0)
        {
            _spriteRef.flipY = false;
        }
    }
}
