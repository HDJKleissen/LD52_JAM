using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler))]
public class RotateRigidbodyByInput: MonoBehaviour
{
    public Rigidbody2D body;
    public PlayerInputHandler inputHandler;
    public float RotationOffset = 90f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inputHandler.MovementInput != Vector2.zero)
        {
            body.SetRotation(Mathf.Atan2(inputHandler.MovementInput.y, inputHandler.MovementInput.x) * Mathf.Rad2Deg + RotationOffset);
        }

    }
}