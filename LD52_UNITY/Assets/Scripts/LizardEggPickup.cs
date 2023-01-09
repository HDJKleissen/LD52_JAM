using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardEggPickup : MonoBehaviour
{
    public bool pickupable = true;
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
        if (collision.GetComponent<EnemyAttack>() != null)
        {
            Destroy(gameObject);
            // SFX: Egg break
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/BabyDeathLizard", gameObject);
        }
        else
        {
            EggDrop eggDrop = collision.GetComponent<EggDrop>();
            if(eggDrop != null)
            {
                eggDrop.eggs++;
                Destroy(gameObject);
                // SFX: Egg success~!
            }
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
