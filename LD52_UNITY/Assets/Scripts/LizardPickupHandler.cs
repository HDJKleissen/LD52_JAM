using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardPickupHandler : MonoBehaviour
{
    public GameObject LizardEggPrefab;
    public GameObject LizardEggPickupPrefab;
    public Transform EggHolder;

    public bool CarryingEgg;
    GameObject egg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DropEgg()
    {
        LizardEggPickup pickup = Instantiate(LizardEggPickupPrefab).GetComponent<LizardEggPickup>();
        pickup.transform.position = transform.position;
        pickup.pickupable = false;
        Destroy(egg);
        CarryingEgg = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LizardEggPickup eggPickup = collision.GetComponent<LizardEggPickup>();

        if (eggPickup != null && !CarryingEgg && eggPickup.pickupable)
        {
            egg = Instantiate(LizardEggPrefab, EggHolder);
            egg.transform.localPosition = new Vector3(0, 0, -0.1f);
            CarryingEgg = true;

            Destroy(eggPickup.gameObject);
        }
        if (collision.GetComponent<EnemyAttack>() != null)
        {
            // TODO: Move to seperate class and attach level end
            Destroy(gameObject);
        }
    }
}
