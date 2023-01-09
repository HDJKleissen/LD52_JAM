using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusController : MonoBehaviour
{
    List<Cactus> Cacti;
    public float CactusKillCooldownMin, CactusKillCooldownMax;

    // Start is called before the first frame update
    void Start()
    {
        Cacti = new List<Cactus>(FindObjectsOfType<Cactus>());
        StartCoroutine(KillCactus());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator KillCactus()
    {
        while(Cacti.Count > 0)
        {
            yield return new WaitForSeconds(Random.Range(CactusKillCooldownMin, CactusKillCooldownMax));
            Cactus cactus = Cacti[Random.Range(0, Cacti.Count)];
            Cacti.Remove(cactus);
            cactus.KillCactus();
        }
    }
}
