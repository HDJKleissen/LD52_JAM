using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : UnitySingleton<MusicPlayer>
{
    FMOD.Studio.EventInstance Music;

    public bool Menu;

    void Start()
    {
        if (Instance == this)
        {
            Music = FMODUnity.RuntimeManager.CreateInstance("event:/Music");
            Music.start();
            Music.release();
            DontDestroyOnLoad(this);
            SetMenu(true);
        }
    }

    private void Update()
    {
        SetMenu(Menu);
    }

    public void SetMenu(bool value)
    {
        Music.setParameterByName("Menu", value ? 1f : 0f, false);
        Menu = value;
    }

    private void OnDestroy()
    {
        Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
