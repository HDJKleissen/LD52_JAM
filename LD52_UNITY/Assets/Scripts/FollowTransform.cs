using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowTransform : MonoBehaviour
{
    public Rigidbody2D body;
    public Rigidbody2D leader; // the game object to follow - assign in inspector
    public int steps = 10; // number of steps to stay behind - assign in inspector

    private Queue<Vector2> positionRecord = new Queue<Vector2>();
    private Queue<float> rotationRecord = new Queue<float>();

    // Start is called before the first frame update
    void Start()
    {
        if(body == null)
        {
            body = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (leader.velocity != Vector2.zero)
        {
            // record position of leader
            positionRecord.Enqueue(leader.transform.position);
            rotationRecord.Enqueue(leader.rotation);

            // remove last position from the record and use it for our own
            if (positionRecord.Count > steps)
            {
                transform.position = positionRecord.Dequeue();
            }
            // remove last position from the record and use it for our own
            if (rotationRecord.Count > steps)
            {
                body.rotation = rotationRecord.Dequeue();
            }
        }
    }
}