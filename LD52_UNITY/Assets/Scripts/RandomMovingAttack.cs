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

    FMOD.Studio.EventInstance combineSound;

    public bool IsCombine;

    private void Start()
    {
    }

    public override void SetupAttack(LevelController controller)
    {
        Bounds bounds = controller.LevelBounds;
        bool vertical = Random.Range(0, 1f) > 0.5f;
        bool startPosOne = Random.Range(0, 1f) > 0.5f;
        float xStart = vertical ? Random.Range(bounds.min.x + sprite.sprite.bounds.size.x, bounds.max.x - sprite.sprite.bounds.size.x) : startPosOne ? bounds.min.x - sprite.sprite.bounds.size.x: bounds.max.x + sprite.sprite.bounds.size.x ;
        float yStart = !vertical ? Random.Range(bounds.min.y + sprite.sprite.bounds.size.y, bounds.max.y - sprite.sprite.bounds.size.y) : startPosOne ? bounds.min.y - sprite.sprite.bounds.size.y  : bounds.max.y + sprite.sprite.bounds.size.y ;
        startPosition = new Vector2(xStart, yStart);
        float xEnd = vertical ? xStart : startPosOne ? bounds.max.x + sprite.sprite.bounds.size.x : bounds.min.x - sprite.sprite.bounds.size.x;
        float yEnd = !vertical ? yStart : startPosOne ? bounds.max.y + sprite.sprite.bounds.size.y : bounds.min.y - sprite.sprite.bounds.size.y;
        endPosition = new Vector2(xEnd, yEnd);

        transform.SetPositionAndRotation(startPosition, Quaternion.Euler(0, 0, Mathf.Atan2((startPosition - endPosition).y, (startPosition - endPosition).x) * Mathf.Rad2Deg + 90f));
    }

    public override void StartAttack(LevelController controller)
    {
        startTime = Time.time;
        endTime = startTime + AttackDuration;
        // SFX: Combine start
        if (IsCombine)
        {
            combineSound = FMODUnity.RuntimeManager.CreateInstance("event:/Combine");
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(combineSound, transform);
            combineSound.start();
            combineSound.release();
        }
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
                // SFX: Combine end
                if (IsCombine)
                {
                    combineSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                }
                HandleAttackEnd();
            }
        }
    }

    private void OnDestroy()
    {
        if (IsCombine)
        {
            combineSound.release();
            combineSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}