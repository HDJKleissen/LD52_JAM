using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrogController : PlayerController
{
    public Transform LandingTarget;

    public Animator Animator;

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
            Animator.SetTrigger("JumpPrep");
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
                Animator.SetTrigger("JumpPrep");
            }

            if ((jumpDirection.x != 0 && Mathf.Sign(jumpDirection.x) != Mathf.Sign(cardinalizedDirection.x))
                || (jumpDirection.y != 0 && Mathf.Sign(jumpDirection.y) != Mathf.Sign(cardinalizedDirection.y)))
            {
                moving = true;
                LandingTarget.gameObject.SetActive(false);
                LandingTarget.localPosition = Vector2.zero;
                Animator.SetTrigger("Jump");
                StartCoroutine(MoveTo(jumpDirection * jumpStrength));
            }

            jumpStrength += MaxJumpStrength / (FullJumpChargeTime * (1 + frogsCarried * 0.1f)) * Time.deltaTime;
            jumpStrength = Mathf.Clamp(jumpStrength, 0, MaxJumpStrength);

            LandingTarget.localPosition = jumpStrength * Vector2.up;
            body.SetRotation(Mathf.Atan2(jumpDirection.y, jumpDirection.x) * Mathf.Rad2Deg -90f);
        }
    }


    public override void HandleMovementRelease(Vector2 lastInput)
    {
        moving = true;
        LandingTarget.gameObject.SetActive(false);
        LandingTarget.localPosition = Vector2.zero;
        StartCoroutine(MoveTo(jumpDirection * jumpStrength));
        Animator.SetTrigger("Jump");
    }

    IEnumerator MoveTo(Vector2 destination)
    {
        Vector2 startPosition = body.position;
        Vector2 endPosition = body.position + destination;
        // SFX: Jump Hop
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Hop", gameObject);

        float time = 0;
        while (time <= JumpTime)
        {
            transform.position = Vector2.Lerp(startPosition, endPosition, VelocityCurve.Evaluate(time / JumpTime));
            time += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }


        jumpStrength = 0;
        jumpDirection = Vector2.zero;
        Animator.SetTrigger("JumpFinish");
        // SFX: Jump Land
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/FrogLand", gameObject);
        yield return new WaitForSeconds(MoveCooldown * (1 - 0.1f * frogsCarried));

        moving = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere((Vector2)transform.position + (jumpDirection * jumpStrength), 1);
    }
}