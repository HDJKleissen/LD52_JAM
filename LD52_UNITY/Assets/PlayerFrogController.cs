using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrogController : PlayerController
{
    public Transform LandingTarget;

    public AnimationCurve VelocityCurve;
    public float JumpTime;
    public float MoveCooldown;
    public float MaxJumpStrength;
    public float FullJumpChargeTime;

    bool moving = false;

    public int frogsCarried = 0;

    public Vector2 jumpDirection;
    public float jumpStrength;

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
        if (!moving)
        {
            jumpStrength = 0;
            Vector2 cardinalizedDirection;

            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                cardinalizedDirection = new Vector2(input.x, 0);
            }
            else
            {
                cardinalizedDirection = new Vector2(0, input.y);
            }

            jumpDirection = cardinalizedDirection.normalized;
            LandingTarget.gameObject.SetActive(true);
        }
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
            else if (Mathf.Abs(input.x) < Mathf.Abs(input.y))
            {
                cardinalizedDirection = new Vector2(0, input.y);
            }
            else
            {
                cardinalizedDirection = jumpDirection;
            }

            if (jumpDirection == Vector2.zero)
            {
                jumpStrength = 0;
                jumpDirection = cardinalizedDirection.normalized;
                LandingTarget.gameObject.SetActive(true);
            }

            if ((jumpDirection.x != 0 && Mathf.Sign(jumpDirection.x) != Mathf.Sign(cardinalizedDirection.x))
                || (jumpDirection.y != 0 && Mathf.Sign(jumpDirection.y) != Mathf.Sign(cardinalizedDirection.y)))
            {
                moving = true;
                LandingTarget.gameObject.SetActive(false);
                LandingTarget.localPosition = Vector2.zero;
                StartCoroutine(MoveTo(jumpDirection * jumpStrength));
            }

            jumpStrength += MaxJumpStrength / (FullJumpChargeTime * (1 + frogsCarried * 0.1f)) * Time.deltaTime;
            jumpStrength = Mathf.Clamp(jumpStrength, 0, MaxJumpStrength);

            LandingTarget.localPosition = jumpStrength * jumpDirection;
        }
    }


    public override void HandleMovementRelease(Vector2 lastInput)
    {
        moving = true;
        LandingTarget.gameObject.SetActive(false);
        LandingTarget.localPosition = Vector2.zero;
        StartCoroutine(MoveTo(jumpDirection * jumpStrength));
    }

    IEnumerator MoveTo(Vector2 destination)
    {
        Vector2 startPosition = body.position;
        Vector2 endPosition = body.position + destination;

        float time = 0;
        while (time <= JumpTime)
        {
            transform.position = Vector2.Lerp(startPosition, endPosition, VelocityCurve.Evaluate(time / JumpTime));
            time += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }


        jumpStrength = 0;
        jumpDirection = Vector2.zero;
        yield return new WaitForSeconds(MoveCooldown * (1 - 0.1f * frogsCarried));

        moving = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere((Vector2)transform.position + (jumpDirection * jumpStrength), 1);
    }
}