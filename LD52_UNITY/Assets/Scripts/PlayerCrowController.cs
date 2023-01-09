using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using UnityEngine.SceneManagement;

public class PlayerCrowController : PlayerController
{
    public Disc Shadow;
    public Animator animator;
    public float TurnSpeed;
    public float SlowdownSpeed;
    public float MoveSpeed;
    public float MinSpeed;
    public float SwoopTransitionTime;
    public float SwoopPickupTime;
    bool swooping;
    bool canPickup;

    Color shadowColor;
    public int ShiniesPickedUp = 0;

    public override void HandleActionHeld()
    {
    }

    public override void HandleActionPress()
    {
        if (!swooping)
        {
            // SFX: Crow swoop sound
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/CrowSwoop", gameObject);
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Caw", gameObject);

            StartCoroutine(Swoop());
        }
    }

    public override void HandleActionRelease()
    {
    }

    public override void HandleMovementHeld(Vector2 input)
    {
        if (!swooping)
        {
            Movement = Vector2.Lerp(Movement.normalized, input.normalized, TurnSpeed) * MoveSpeed;
        }
    }

    public override void HandleMovementPress(Vector2 input)
    {
    }

    public override void HandleMovementRelease(Vector2 lastInput)
    {
    }

    IEnumerator Swoop()
    {
        swooping = true;

        float startTime = Time.time;
        while(Time.time < startTime+ SwoopTransitionTime)
        {
            transform.localScale = Vector3.Lerp(Vector3.one, new Vector3(0.8f, 0.8f, 1), (Time.time - startTime) / SwoopTransitionTime);
            Movement = Vector2.Lerp(Movement, Movement.normalized * MoveSpeed * 1.2f, (Time.time - startTime) / SwoopTransitionTime);
            Shadow.Color = Color.Lerp(shadowColor, new Color(shadowColor.r, shadowColor.g, shadowColor.b, 0), (Time.time - startTime) / SwoopTransitionTime);
            yield return null;
        }
        canPickup = true;
        yield return new WaitForSeconds(SwoopPickupTime);

        canPickup = false;
        float startTime2 = Time.time;
        while (Time.time < startTime2 + SwoopTransitionTime)
        {
            transform.localScale = Vector3.Lerp(new Vector3(0.8f, 0.8f, 1), Vector3.one, (Time.time - startTime2) / SwoopTransitionTime);
            Movement = Vector2.Lerp(Movement, Movement.normalized * MoveSpeed, (Time.time - startTime) / SwoopTransitionTime);
            Shadow.Color = Color.Lerp(new Color(shadowColor.r, shadowColor.g, shadowColor.b, 0), shadowColor,(Time.time - startTime2) / SwoopTransitionTime);
            yield return null;
        }

        swooping = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        shadowColor = Shadow.Color;
        Movement = Vector2.up;
    }

    // Update is called once per frame
    void Update()
    {
        if (Movement.magnitude < (MinSpeed + MoveSpeed)/2)
        {
            animator.speed = 0.5f;
        }
        else
        {
            animator.speed = 1;
        }
        if (!swooping)
        {
            Movement = Vector2.Lerp(Movement, Movement.normalized * MinSpeed, SlowdownSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canPickup)
        {
            if (collision.GetComponent<EnemyAttack>() != null)
            {
                // TODO: Move to seperate class and attach level end
                // SFX: Player crow death
                FMODUnity.RuntimeManager.PlayOneShotAttached("event:/PlayerDeathCrow", gameObject);

                int score = GetScore();
                if (score > PlayerPrefs.GetInt("CrowScore"))
                {
                    PlayerPrefs.SetInt("CrowScore", score);
                }
                SceneManager.LoadScene("LevelSelect");
            }
            else if (collision.GetComponent<CrowShinyPickup>() != null)
            {
                // SFX: Shiny pickup
                FMODUnity.RuntimeManager.PlayOneShotAttached("event:/PickupCrow", gameObject);
                ShiniesPickedUp++;
                Destroy(collision.gameObject);
            }
        }
    }

    public override int GetScore()
    {
        return ShiniesPickedUp;
    }
}