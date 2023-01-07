using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RotateRigidbodyByMovement : MonoBehaviour
{
    public Rigidbody2D body;
    [Range(0, 1)]
    public float RotateSpeed = 0.3f;

    float DestinationRotation;

    // Start is called before the first frame update
    void Start()
    {
        if(body == null)
        {
            body = GetComponent<Rigidbody2D>();
        }
        DestinationRotation = body.rotation;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (body.velocity != Vector2.zero)
        {
            DestinationRotation = Mathf.Atan2(body.velocity.y, body.velocity.x) * Mathf.Rad2Deg + 90f;
        }

        body.SetRotation(Mathf.LerpAngle(body.rotation, DestinationRotation, RotateSpeed));
    }
}