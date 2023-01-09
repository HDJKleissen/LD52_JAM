using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyMouse : MonoBehaviour
{
    FollowTarget MomMouse;
    public Animator Animator;

    Vector3 prevPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Animator.speed = prevPosition != transform.position ? 1 : 0;

        prevPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<EnemyAttack>() != null)
        {
            Destroy(gameObject);
            // SFX: Baby mouse death
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/BabyDeathMouse", gameObject);
        }
    }
}
