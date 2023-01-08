using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrowController : PlayerController
{
    public float TurnSpeed;
    public float SlowdownSpeed;
    public float MoveSpeed;
    public float MinSpeed;

    public override void HandleActionHeld()
    {
    }

    public override void HandleActionPress()
    {
    }

    public override void HandleActionRelease()
    {
    }

    public override void HandleMovementHeld(Vector2 input)
    {
        Movement = Vector2.Lerp(Movement.normalized, input.normalized, TurnSpeed) * MoveSpeed;
    }

    public override void HandleMovementPress(Vector2 input)
    {
    }

    public override void HandleMovementRelease(Vector2 lastInput)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement = Vector2.Lerp(Movement, Movement.normalized * MinSpeed, SlowdownSpeed);
    }
}
