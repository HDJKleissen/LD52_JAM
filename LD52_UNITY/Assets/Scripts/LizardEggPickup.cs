using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardEggPickup : MonoBehaviour
{
    public bool pickupable = false;
    EggDrop eggDrop;

    // Start is called before the first frame update
    void Start()
    {

        eggDrop = FindObjectOfType<EggDrop>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, eggDrop.transform.position) < 5f)
        {
            eggDrop.eggs++;
            Destroy(gameObject);
            // SFX: Egg success~!
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Pickup", gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyAttack>() != null)
        {
            Destroy(gameObject);
            // SFX: Egg break
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/BabyDeathLizard", gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<LizardPickupHandler>())
        {
            pickupable = true;
        }
    }
}
