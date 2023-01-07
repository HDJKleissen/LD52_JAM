using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TargetFollower : MonoBehaviour
{
    public FollowTarget Leader;
    public Rigidbody2D body;

    public float MoveLerpValue = 0.3f;
    public Vector2 Destination;

    // Start is called before the first frame update
    void Start()
    {
        if (body == null)
        {
            body = GetComponent<Rigidbody2D>();
        }
        Destination = transform.position;

        Collider2D myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Leader.CanGetDestination(this))
        {
            Destination = Leader.GetDestination(this);
        }
        else
        {
            Destination = body.position;
        }
        if (Leader.CanGetRotation(this))
        {
            body.rotation = Leader.GetRotation(this);
        }
        else
        {
            Destination = body.position;
        }

        if (Vector2.Distance(body.position, Destination) > 0.01f)
        {
            body.position = Vector2.Lerp(body.position, Destination, MoveLerpValue);
        }
    }
}