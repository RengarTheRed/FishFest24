using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private PlayerInputMap _myActions;
    private Rigidbody2D _rigidbody2D;
    
    #region Movement Variables
    [Header("Movement Variables")]
    public float _moveSpeed = 5f;
    Vector2 _moveToApply; // Variable used in FixedUpdate
    
    #endregion
    
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
    }
}