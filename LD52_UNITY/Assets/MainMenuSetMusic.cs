using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSetMusic : MonoBehaviour
{
    public MusicPlayer MusicPlayer;
    // Start is called before the first frame update
    void Start()
    {
        SetMusicIsMenu(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMusicIsMenu(bool value)
    {
        if(MusicPlayer == null)
        {
            MusicPlayer = FindObjectOfType<MusicPlayer>();
        }
        MusicPlayer.SetMenu(value);

    }
}
