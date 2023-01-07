using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrogController : PlayerController
{
    public AnimationCurve VelocityCurve;
    public float VelocityModifier;
    public float JumpTime;
    public float MoveCooldown;

    bool moving = false;

    public int frogsCarried = 0;

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
        if (!moving)
        {
            Vector2 cardinalizedDirection;

            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                cardinalizedDirection = new Vector2(input.x, 0);
            }
            else
            {
                cardinalizedDirection = new Vector2(0, input.y);
            }

            moving = true;
            StartCoroutine(Move(cardinalizedDirection));
        }
    }

    public override void HandleMovementPress(Vector2 input)
    {
    }

    public override void HandleMovementRelease(Vector2 lastInput)
    {
    }

    IEnumerator Move(Vector2 direction)
    {
        Movement = Vector2.zero;
        float time = 0;
        while(time <= JumpTime)
        {
            Movement = direction * VelocityCurve.Evaluate(time / JumpTime) * (VelocityModifier - frogsCarried);
            time += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        Movement = Vector2.zero;

        yield return new WaitForSeconds(MoveCooldown * (1- 0.1f * frogsCarried));

        moving = false;
    }
}
