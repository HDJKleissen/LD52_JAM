using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrogPickupHandler : MonoBehaviour
{
    public GameObject BabyFrogPrefab;
    public PlayerFrogController frogController;
    public Transform BabyFrogHolder;
    
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
        BabyFrogPickup frogPickup = collision.GetComponent<BabyFrogPickup>();

        if (frogPickup != null)
        {
            GameObject frog = Instantiate(BabyFrogPrefab, BabyFrogHolder);
            frog.transform.localPosition = new Vector2(Random.Range(-.4f, .4f), Random.Range(-.8f, -.1f));
            frogController.frogsCarried++;
            Destroy(frogPickup.gameObject);
            // SFX: Baby frog pickup sound
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Pickup", gameObject);
        }
        if (collision.GetComponent<EnemyAttack>() != null)
        {
            // TODO: Move to seperate class and attach level end
            // SFX: Frog player death
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/PlayerDeathFrog", gameObject);

            int score = frogController.GetScore();
            if (score > PlayerPrefs.GetInt("FrogScore",0))
            {
                PlayerPrefs.SetInt("FrogScore", score);
            }
            SceneManager.LoadScene("LevelSelect");        }
    }
}
