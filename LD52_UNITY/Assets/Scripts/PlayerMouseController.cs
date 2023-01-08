using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePlayerController : PlayerController
{
    public FollowTarget FollowTarget;
    public float MoveSpeed = 8f;
    float speedModifier = 1;
    public override void HandleActionHeld()
    {
    }

    public override void HandleActionPress()
    {
        speedModifier = 2;
    }

    public override void HandleActionRelease()
    {
        speedModifier = 1;
    }

    public override void HandleMovementPress(Vector2 input)
    {
        
    }

    public override void HandleMovementHeld(Vector2 input)
    {
        Movement = input.normalized * MoveSpeed * speedModifier;
    }

    public override void HandleMovementRelease(Vector2 lastInput)
    {
        Movement = Vector2.zero;
    }
}
