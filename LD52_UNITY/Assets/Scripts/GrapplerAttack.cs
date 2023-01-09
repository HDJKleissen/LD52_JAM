using System.Collections;
using System.Collections.Generic;
using Shapes;
using UnityEngine;

public class GrapplerAttack : EnemyAttack
{
    public float WindupTime;
    public SpriteRenderer grapple;
    public Collider2D damageCollider;
    public Sprite ClosedSprite;
    float startTime, endTime;

    bool goingUp = false;

    public override void SetupAttack(LevelController controller)
    {
        transform.position = new Vector2(Random.Range(controller.LevelBounds.min.x, controller.LevelBounds.max.x), Random.Range(controller.LevelBounds.min.y, controller.LevelBounds.max.y));
    }

    public override void StartAttack(LevelController controller)
    {
        startTime = Time.time;
        endTime = startTime + WindupTime;
        // SFX: Grapple go down sound?
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/GrapplerDown", gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (damageCollider.enabled == true && !goingUp)
        {
            // SFX: Grapple go up sound?
            damageCollider.enabled = false;
            goingUp = true;
            StartCoroutine(GrappleLeave());
        }
        grapple.color = Color.Lerp(new Color(0,0,0,0), new Color(1,1,1,1), 1-((endTime - Time.time) / WindupTime));

        if(Time.time > endTime && !goingUp)
        {
            grapple.sprite = ClosedSprite;
            damageCollider.enabled = true;
        }
    }

    IEnumerator GrappleLeave()
    {
        float alpha = 1;
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/GrapplerClose", gameObject);

        while (alpha > 0)
        {
            grapple.color = new Color(1, 1, 1, Mathf.Clamp01(alpha));
            alpha -= Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
