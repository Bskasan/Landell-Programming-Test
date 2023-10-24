using System;
using System.Diagnostics;
using UnityEngine;

public static class MoveHandlerDataManager
{
    //TODO: Add Run & Jump

    #region Events
    
    public static event Action<Vector2> OnMove;
    public static event Action<bool> OnRun;
    public static event Action<float> OnJump;

    #endregion


    #region Invoke Methods

    public static void Move(this MoveInputManager moveInputManager, Vector2 direction) => OnMove?.Invoke(direction);
    public static void Run(this MoveInputManager moveInputManager, bool isPressed) => OnRun?.Invoke(isPressed);
    public static void Jump(this MoveInputManager moveInputManager, float jumpForce) => OnJump?.Invoke(jumpForce);

    #endregion

}