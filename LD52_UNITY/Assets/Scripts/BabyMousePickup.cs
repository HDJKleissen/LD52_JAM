using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyMousePickup : MonoBehaviour
{
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
            // SFX: Baby mouse death
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/BabyDeathMouse", gameObject);
        }
    }
}
