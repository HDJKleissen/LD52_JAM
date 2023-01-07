using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePlayerController : PlayerController
{
    public float MoveSpeed = 8f;

    public override void HandleActionHeld()
    {
    }

    public override void HandleActionPress()
    {
        
    }

    public override void HandleActionRelease()
    {
        
    }

    public override void HandleMovementPress(Vector2 input)
    {
        
    }

    public override void HandleMovementHeld(Vector2 input)
    {
        Movement = input * MoveSpeed;
    }

    public override void HandleMovementRelease(Vector2 lastInput)
    {
        Movement = Vector2.zero;
    }
}
