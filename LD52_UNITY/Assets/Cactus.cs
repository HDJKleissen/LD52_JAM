using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public GameObject DeadCactus, AliveCactus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillCactus()
    {
        DeadCactus.SetActive(true);
        AliveCactus.SetActive(false);
        // SFX: Cactus break
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/CactusFall", gameObject);

    }
}
