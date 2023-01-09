using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;

    protected Vector2 Movement;
    
    public abstract void HandleMovementPress(Vector2 input);
    public abstract void HandleMovementHeld(Vector2 input);
    public abstract void HandleMovementRelease(Vector2 lastInput);
    public abstract void HandleActionHeld();

    public abstract void HandleActionPress();

    public abstract void HandleActionRelease();

    private void FixedUpdate()
    {
        body.velocity = Movement;
    }

    public abstract int GetScore();
}
