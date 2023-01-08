using UnityEngine;

public class PlayerLizardController : PlayerController
{
    public Animator animator;
    public LizardPickupHandler pickupHandler;
    public float TurnSpeed;
    public float MoveSpeed;
    public float SlowdownRate;
    Vector2 storedInput;

    public override void HandleActionHeld()
    {
    }

    public override void HandleActionPress()
    {
        if (pickupHandler.CarryingEgg)
        {
            pickupHandler.DropEgg();
        }
    }

    public override void HandleActionRelease()
    {
    }

    public override void HandleMovementHeld(Vector2 input)
    {
        storedInput = Vector2.Lerp(storedInput, input, TurnSpeed / (Movement / MoveSpeed).magnitude);
        Movement = storedInput.normalized * MoveSpeed;
        animator.speed = 1;
    }

    public override void HandleMovementPress(Vector2 input)
    {
    }

    public override void HandleMovementRelease(Vector2 lastInput)
    {
        animator.speed = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        Movement = Vector2.Lerp(Movement, Vector2.zero, SlowdownRate);
    }

    public void Start()
    {
        animator.speed = 0;
    }
}