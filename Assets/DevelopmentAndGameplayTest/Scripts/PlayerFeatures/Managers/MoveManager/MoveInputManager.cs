using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveInputManager : MonoBehaviour
{
    //TODO: Create Run & Jump

    private void OnMove(InputValue value)
    {
        this.Move(value.Get<Vector2>());
    }

    private void OnRun(InputValue value)
    {
        this.Run(value.isPressed);
    }

    private void OnJump(InputValue value)
    {
        this.Jump(value.Get<float>());
    }
}