using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDebugController : PlayerController
{
    public override int GetScore()
    {
        return 0;
    }

    public override void HandleActionHeld()
    {
        Debug.Log("Action held");
    }

    public override void HandleActionPress()
    {
        Debug.Log("Action pressed");
    }

    public override void HandleActionRelease()
    {
        Debug.Log("Action released");
    }


    public override void HandleMovementHeld(Vector2 input)
    {
        Debug.Log("Movement held: " + input);
    }

    public override void HandleMovementPress(Vector2 input)
    {
        Debug.Log("Movement pressed: " + input);
    }

    public override void HandleMovementRelease(Vector2 lastInput)
    {
        Debug.Log("Movement released, last input: " + lastInput);
    }
}
