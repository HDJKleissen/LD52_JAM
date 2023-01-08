using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyFrogPickup : MonoBehaviour
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
        Debug.Log("OW");
        if (collision.GetComponent<EnemyAttack>() != null)
        {
            Debug.Log("I'm DEAD!");
            Destroy(gameObject);
            // SFX: Baby frog death
        }
    }
}
