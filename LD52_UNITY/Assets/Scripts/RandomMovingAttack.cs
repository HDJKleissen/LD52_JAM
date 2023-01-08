using Shapes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovingAttack : EnemyAttack
{
    Vector2 startPosition, endPosition;

    public float AttackDuration;

    float startTime, endTime;
    public SpriteRenderer sprite;

    public override void SetupAttack(LevelController controller)
    {
        Bounds bounds = controller.LevelBounds;
        bool vertical = Random.Range(0, 1f) > 0.5f;
        bool startPosOne = Random.Range(0, 1f) > 0.5f;
        float xStart = vertical ? Random.Range(bounds.min.x, bounds.max.x) : startPosOne ? bounds.min.x : bounds.max.x;
        float yStart = !vertical ? Random.Range(bounds.min.y, bounds.max.y) : startPosOne ? bounds.min.y : bounds.max.y;
        startPosition = new Vector2(xStart, yStart);
        float xEnd = vertical ? xStart : startPosOne ? bounds.max.x : bounds.min.x;
        float yEnd = !vertical ? yStart : startPosOne ? bounds.max.y : bounds.min.y;
        endPosition = new Vector2(xEnd, yEnd);

        transform.SetPositionAndRotation(startPosition, Quaternion.Euler(0, 0, Mathf.Atan2((startPosition - endPosition).y, (startPosition - endPosition).x) * Mathf.Rad2Deg + 90f));
    }

    public override void StartAttack(LevelController controller)
    {
        startTime = Time.time;
        endTime = startTime + AttackDuration;
        sprite.enabled = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (startTime != 0)
        {
            transform.position = Vector2.Lerp(startPosition, endPosition, (Time.time - startTime) / AttackDuration);
            if (Time.time > endTime)
            {
                HandleAttackEnd();
            }
        }
    }
}