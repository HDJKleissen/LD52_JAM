using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MousePickupHandler : MonoBehaviour
{
    public GameObject BabyMousePrefab;
    public List<BabyMouse> babyList = new List<BabyMouse>();

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
        Debug.Log("Trigger!");
        BabyMousePickup mousePickup = collision.GetComponent<BabyMousePickup>();

        Debug.Log(mousePickup);
        if (mousePickup != null) {
            BabyMouse mouse = Instantiate(BabyMousePrefab).GetComponent<BabyMouse>();
            mouse.transform.position = mousePickup.transform.position;

            Destroy(mousePickup.gameObject);

            FollowTransform follow = mouse.GetComponent<FollowTransform>();
            if(babyList.Count < 1)
            {
                follow.leader = GetComponent<Rigidbody2D>();
            }
            else
            {
                follow.leader = babyList.Last().GetComponent<Rigidbody2D>();
            }

            babyList.Add(mouse);
        }
    }
}
