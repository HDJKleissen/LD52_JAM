using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowTransform : MonoBehaviour
{
    public Rigidbody2D body;
    public Rigidbody2D leader; // the game object to follow - assign in inspector
    public int steps = 10; // number of steps to stay behind - assign in inspector
    public float minDistance;


    [Range(0, 1f)]
    public float MoveLerpValue = 0.3f;

    private Queue<Vector2> positionRecord = new Queue<Vector2>();
    private Queue<float> rotationRecord = new Queue<float>();

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
        Collider2D leaderCollider = leader.GetComponent<Collider2D>();

        minDistance = Mathf.Max(myCollider.bounds.extents.x, myCollider.bounds.extents.y) + Mathf.Max(leaderCollider.bounds.extents.x, leaderCollider.bounds.extents.y);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Vector2.Distance(body.position, leader.position) > minDistance)
        {
            // record position of leader
            positionRecord.Enqueue(leader.transform.position);
            rotationRecord.Enqueue(leader.rotation);
        }
        // remove last position from the record and use it for our own
        while (positionRecord.Count > steps)
        {
            Destination = positionRecord.Dequeue();
        }
        // remove last position from the record and use it for our own
        while (rotationRecord.Count > steps)
        {
            body.rotation = rotationRecord.Dequeue();
        }
        if (Vector2.Distance(body.position, Destination) > 0.01f)
        {
            body.position = Vector2.Lerp(body.position, Destination, MoveLerpValue);
        }
    }
}