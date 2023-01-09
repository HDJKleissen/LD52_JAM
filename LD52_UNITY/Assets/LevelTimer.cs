using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public PlayerController player;
    public string ScorePrefsName;
    public float MaxTime;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        time = MaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(time < 0)
        {
            // 10 free score for living until the end
            int score = player.GetScore() + 10;
            if (score > PlayerPrefs.GetInt(ScorePrefsName))
            {
                PlayerPrefs.SetInt(ScorePrefsName, score);
            }
            SceneManager.LoadScene("LevelSelect");
        }
        timerText.text = "Time remaining: " + time.ToString("0.00");
        time -= Time.deltaTime;
    }
}
