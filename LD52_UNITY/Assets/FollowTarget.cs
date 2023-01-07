using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Rigidbody2D body;

    private List<Vector2> positionRecord = new List<Vector2>();
    private List<float> rotationRecord = new List<float>();

    List<TargetFollower> followers = new List<TargetFollower>();

    public int Steps = 10;
    int maxSteps = 0;

    Vector2 lastPosition;
    float lastRotation;

    // Start is called before the first frame update
    void Start()
    {
        if (body == null)
        {
            body = GetComponent<Rigidbody2D>();
        }
    }

    public void AddFollower(TargetFollower follower)
    {
        follower.Leader = this;
        followers.Add(follower);
        maxSteps = followers.Count * Steps;
    }

    internal Vector2 GetDestination(TargetFollower follower)
    {
        return positionRecord[Mathf.Clamp(followers.IndexOf(follower) * Steps, 0, positionRecord.Count)];
    }
    internal float GetRotation(TargetFollower follower)
    {
        return rotationRecord[Mathf.Clamp(followers.IndexOf(follower) * Steps, 0, rotationRecord.Count)];
    }

    internal bool CanGetDestination(TargetFollower follower)
    {
        return followers.IndexOf(follower) * Steps < positionRecord.Count;
    }
    internal bool CanGetRotation(TargetFollower follower)
    {
        return followers.IndexOf(follower) * Steps < rotationRecord.Count;
    }

    public void RemoveFollower(TargetFollower follower)
    {
        followers.Remove(follower);
        maxSteps = followers.Count * Steps;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (body.position != lastPosition)
        {
            positionRecord.Add(body.position);
            rotationRecord.Add(body.rotation);
        }

        while (positionRecord.Count > maxSteps)
        {
            positionRecord.RemoveAt(0);
        }
        while (rotationRecord.Count > maxSteps)
        {
            rotationRecord.RemoveAt(0);
        }

        lastPosition = body.position;
        lastRotation = body.rotation;
    }
}