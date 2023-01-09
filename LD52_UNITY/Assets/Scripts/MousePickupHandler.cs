using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MousePickupHandler : MonoBehaviour
{
    public GameObject BabyMousePrefab;
    public FollowTarget followTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BabyMousePickup mousePickup = collision.GetComponent<BabyMousePickup>();

        if (mousePickup != null) {
            BabyMouse mouse = Instantiate(BabyMousePrefab).GetComponent<BabyMouse>();
            mouse.transform.position = mousePickup.transform.position;

            Destroy(mousePickup.gameObject);

            TargetFollower follower = mouse.GetComponent<TargetFollower>();
            followTarget.AddFollower(follower);
        }
        if (collision.GetComponent<EnemyAttack>() != null)
        {
            // TODO: Move to seperate class and attach level end
            // SFX: Player mouse death
            Destroy(gameObject);
        }
    }
}
