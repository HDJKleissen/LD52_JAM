using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreShower : MonoBehaviour
{
    public string ScoreName;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Highest score: " + PlayerPrefs.GetInt(ScoreName, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
