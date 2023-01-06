using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;

    [Range(0,1)]
    public float RotateSpeed;
    protected Vector2 Movement;
    float DestinationRotation;
    
    public void Start()
    {
        DestinationRotation = body.rotation;
    }

    public abstract void HandleMovementPress(Vector2 input);
    public abstract void HandleMovementHeld(Vector2 input);
    public abstract void HandleMovementRelease(Vector2 lastInput);
    public abstract void HandleActionHeld();

    public abstract void HandleActionPress();

    public abstract void HandleActionRelease();

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Movement != Vector2.zero)
        {
            DestinationRotation = Mathf.Atan2(Movement.y, Movement.x) * Mathf.Rad2Deg + 90f;
        }

        body.SetRotation(Mathf.LerpAngle(body.rotation, DestinationRotation, RotateSpeed));

        body.velocity = Movement;
        
    }
}
