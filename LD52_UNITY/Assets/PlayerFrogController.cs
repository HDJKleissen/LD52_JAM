using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrogController : PlayerController
{
    public AnimationCurve VelocityCurve;
    public float VelocityModifier;
    public float JumpTime;

    bool moving = false;

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
    }

    public override void HandleMovementPress(Vector2 input)
    {
        if (!moving)
        {
            Vector2 cardinalizedDirection;

            if(Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                cardinalizedDirection = new Vector2(input.x, 0);
            }
            else
            {
                cardinalizedDirection = new Vector2(0, input.y);

            }

            StartCoroutine(Move(cardinalizedDirection));
        }
    }

    public override void HandleMovementRelease(Vector2 lastInput)
    {
    }

    IEnumerator Move(Vector2 direction)
    {
        moving = true;

        Movement = Vector2.zero;
        float time = 0;
        while(time <= JumpTime)
        {
            Debug.Log("Time " + time);
            Movement = direction * VelocityCurve.Evaluate(time / JumpTime) * VelocityModifier;
            time += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        Movement = Vector2.zero;
        moving = false;
    }
}
