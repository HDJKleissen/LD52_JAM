using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbiencePlayer : UnitySingleton<AmbiencePlayer>
{
    FMOD.Studio.EventInstance Ambience;

    void Start()
    {
        if (Instance == this)
        {
            Ambience = FMODUnity.RuntimeManager.CreateInstance("event:/Ambience");
            Ambience.start();
            Ambience.release();
            DontDestroyOnLoad(this);
        }
    }

    private void OnDestroy()
    {
        Ambience.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
