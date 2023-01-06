using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public PlayerController controller;

    Vector2 movementInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newMovementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movementInput == Vector2.zero && newMovementInput != Vector2.zero)
        {
            controller.HandleMovementPress(newMovementInput);
        }
        else if (movementInput != Vector2.zero && newMovementInput != Vector2.zero)
        {
            controller.HandleMovementHeld(newMovementInput);
        }
        else if (movementInput != Vector2.zero && newMovementInput == Vector2.zero)
        {
            controller.HandleMovementRelease(movementInput);
        }

        movementInput = newMovementInput;

        if (Input.GetButtonDown("Action"))
        {
            controller.HandleActionPress();
        }
        if (Input.GetButton("Action"))
        {
            controller.HandleActionHeld();
        }
        if (Input.GetButtonUp("Action"))
        {
            controller.HandleActionRelease();
        }
    }
}
