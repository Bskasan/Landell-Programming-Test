using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOnMoveManager : MonoBehaviour
{
    //TODO: Add Run & Jump

    #region Fields

    private CharacterController _cc;
    private InputAction _runAction;
    private InputActionMap _playerActions;


    private Vector2 _moveDirection;
    private Vector3 _movePosition;

    public bool RunIsPressed { get; private set; } = false;

    [Header("Movement Stats")]
    [SerializeField] private float _walkSpeed = 7.5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _runSpeed = 13f;


    [Header("Physics Stats")]
    [SerializeField] private float _gravity = 20;
    
    
    private bool _isPressed;




    #endregion

    #region Initialize Methods

    private void Awake()
    {
        _cc = GetComponent<CharacterController>();
        
    }

    #endregion


    #region Subscribe/Unsubscribe (OnEnable / OnDestroy)

    /// <summary>
    /// Subscribe to Events
    /// </summary>
    private void OnEnable()
    {
        MoveHandlerDataManager.OnMove += OnMove;
        MoveHandlerDataManager.OnRun += OnRun;
        MoveHandlerDataManager.OnJump += OnJump;
        
    }

    /// <summary>
    /// Unsubscribe to Events
    /// </summary>
    private  void OnDestroy()
    {
        MoveHandlerDataManager.OnMove -= OnMove;
        MoveHandlerDataManager.OnRun -= OnRun;
        MoveHandlerDataManager.OnJump -= OnJump;
    }

    #endregion


    #region MonoBehaviour

    private void Update()
    {
        // ShouldRun();
        PlayerMovement();

      
    }

   

    #endregion


    #region Custom Methods

    // Moving
    private void OnMove(Vector2 direction)
    {
        _moveDirection = direction;
    }

    private void OnJump(float jumpForce)
    {
        _jumpForce = jumpForce;
    }

    private void OnRun(bool isPressed)
    {
        _isPressed = isPressed;
    }

    //private bool ShouldRun()
    //{
    //    if (_runAction.IsPressed())
    //        return true;
    //    else
    //        return false;
    //}

    private void PlayerMovement()
    {
        ApplyMoveSpeed();

        ApplyGravity();

        if(!_cc.enabled)return;

        _cc.Move(_movePosition * Time.deltaTime);
        
    }


    private void ApplyMoveSpeed()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // float speed = ShouldRun() ? _runSpeed : _walkSpeed;
        // float moveSpeed = _moveDirection.y < 0 
        Vector3 movement = ((forward * _moveDirection.y) + (right * _moveDirection.x)) * _walkSpeed;
        
        _movePosition = new Vector3(movement.x,_movePosition.y, movement.z);
    }


    private void ApplyGravity()
    {
        if(_cc.isGrounded) return;

        _movePosition.y -= _gravity * Time.deltaTime;
    }

    #endregion
    

    
}