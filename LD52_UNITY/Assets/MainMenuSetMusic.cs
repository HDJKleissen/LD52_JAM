using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSetMusic : MonoBehaviour
{
    public MusicPlayer MusicPlayer;
    // Start is called before the first frame update
    void Start()
    {
        MusicPlayer.SetMenu(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
