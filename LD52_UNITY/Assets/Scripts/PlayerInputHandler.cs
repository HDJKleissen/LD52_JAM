using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputHandler : MonoBehaviour
{
    public PlayerController controller;

    public Vector2 MovementInput { get; private set; }
    public float Deadzone;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newMovementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if(newMovementInput.magnitude < Deadzone)
        {
            newMovementInput = Vector2.zero;
        }

        if (MovementInput == Vector2.zero && newMovementInput != Vector2.zero)
        {
            controller.HandleMovementPress(newMovementInput);
        }
        else if (MovementInput != Vector2.zero && newMovementInput != Vector2.zero)
        {
            controller.HandleMovementHeld(newMovementInput);
        }
        else if (MovementInput != Vector2.zero && newMovementInput == Vector2.zero)
        {
            controller.HandleMovementRelease(MovementInput);
        }

        MovementInput = newMovementInput;

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

        if (Input.GetButtonUp("Pause"))
        {
            SceneManager.LoadScene("LevelSelect");
        }
    }
}
