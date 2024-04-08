using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private PlayerInputMap _myActions;
    private Rigidbody2D _rigidbody2D;
    
    [Header("Movement Variables")]
    public float _moveSpeed = 5f;
    Vector2 _moveToApply; // Variable used in FixedUpdate

    [Header("Sprite Reference")] [SerializeField]
    private SpriteRenderer _playerSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        _myActions = new PlayerInputMap();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _myActions.Game.Enable();
    }

    private void FixedUpdate()
    {
        // Read Move Input
        if (_myActions == null) return;
        _moveToApply = _myActions.Game.Movement.ReadValue<Vector2>();
        _rigidbody2D.AddForce(_moveToApply * _moveSpeed);
        RotateToMouse();
        RotateSprite();
    }

    // Rotate Player to Mouse Cursor Pos
    private void RotateToMouse()
    {
        Vector2 direction = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5f * Time.deltaTime);
    }

    // Sprite Flipping Logic
    private void RotateSprite()
    {
        if (transform.rotation.z > 0)
        {
            _playerSprite.flipY = true;
        }

        if (transform.rotation.z < 0)
        {
            _playerSprite.flipY = false;
        }
    }
}