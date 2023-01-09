using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSounds : MonoBehaviour
{
    public void PlayMouseFootstep()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/MouseStep", gameObject);
    }

    public void PlayLizardFootstep()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/LizardStep", gameObject);
    }

    public void PlayHarveyFootstep()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/HarveyStep", gameObject);
    }

    public void PlayFlap()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Flap", gameObject);
    }

    public void PlayRibbit()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Ribbit", gameObject);
    }
}
