using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.UI;

public class BusController : MonoBehaviour
{
    Bus bus;
    public string busPath;
    private float busVolume;
    private Slider slider;
    EventInstance levelTest;
    PLAYBACK_STATE pb;

    // Start is called before the first frame update
    void Start()
    {
        bus = RuntimeManager.GetBus("bus:/" + busPath);
        bus.getVolume(out busVolume);

        slider = GetComponent<Slider>();
        slider.value = busVolume;

        if (busPath == "SFXBus")
        {
            levelTest = RuntimeManager.CreateInstance("event:/LevelTest");
        }
        else
            levelTest.release();
    }

    public void VolumeLevel(float sliderValue)
    {
        bus.setVolume(sliderValue);
        if (busPath == "SFXBus")
        {
            levelTest.getPlaybackState(out pb);
            if (pb != PLAYBACK_STATE.PLAYING)
            {
                levelTest.start();
            }
        }
    }
}
