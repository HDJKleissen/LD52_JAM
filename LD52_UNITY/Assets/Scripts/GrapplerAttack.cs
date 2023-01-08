using System.Collections;
using System.Collections.Generic;
using Shapes;
using UnityEngine;

public class GrapplerAttack : EnemyAttack
{
    public float WindupTime;
    public Disc warner;
    public Collider2D damageCollider;

    float startTime, endTime;

    public override void SetupAttack(LevelController controller)
    {
        transform.position = new Vector2(Random.Range(controller.LevelBounds.min.x, controller.LevelBounds.max.x), Random.Range(controller.LevelBounds.min.y, controller.LevelBounds.max.y));
    }

    public override void StartAttack(LevelController controller)
    {
        startTime = Time.time;
        endTime = startTime + WindupTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (damageCollider.enabled == true)
        {
            Destroy(gameObject);
        }
        warner.AngRadiansEnd = Mathf.Lerp(0, 2*Mathf.PI, 1-((endTime - Time.time) / WindupTime));

        if(Time.time > endTime)
        {
            damageCollider.enabled = true;
        }
    }
}
