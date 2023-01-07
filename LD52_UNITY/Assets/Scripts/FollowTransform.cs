using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private List<Vector2> positionRecord = new List<Vector2>();
    private List<float> rotationRecord = new List<float>();

    Vector2 lastPositionRecord;
    float lastRotationRecord;

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

        lastPositionRecord = leader.position;
        lastRotationRecord = leader.rotation;
        positionRecord.Add(leader.position);
        rotationRecord.Add(leader.rotation);

        minDistance = Mathf.Max(myCollider.bounds.extents.x, myCollider.bounds.extents.y) + Mathf.Max(leaderCollider.bounds.extents.x, leaderCollider.bounds.extents.y);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (leader.position != lastPositionRecord && (positionRecord.Count > 0 && positionRecord.First() != leader.position))
        {
            // record position of leader
            positionRecord.Add(leader.position);
        }

        if (leader.rotation != lastRotationRecord && (rotationRecord.Count > 0 && rotationRecord.First() != leader.rotation))
        {
            // record rotation of leader
            rotationRecord.Add(leader.rotation);
        }

        // remove last position from the record and use it for our own
        while (positionRecord.Count > steps)
        {
            Destination = positionRecord[0];
            positionRecord.RemoveAt(0);
        }
        // remove last position from the record and use it for our own
        while (rotationRecord.Count > steps)
        {
            body.rotation = rotationRecord[0];
            rotationRecord.RemoveAt(0);
        }
        if (Vector2.Distance(body.position, Destination) > 0.01f)
        {
            body.position = Vector2.Lerp(body.position, Destination, MoveLerpValue);
        }
        lastPositionRecord = leader.position;
        lastRotationRecord = leader.rotation;
    }
}