using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogRibbit : MonoBehaviour
{
    [SerializeField] float ShortestTimeBetweenBarks = 8f;
    [SerializeField] float LongestTimeBetweenBarks = 16f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("PlayBark", Random.Range(ShortestTimeBetweenBarks, LongestTimeBetweenBarks));
    }

    void PlayBark()
    {
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/R16bit", gameObject);
        Invoke("PlayBark", Random.Range(ShortestTimeBetweenBarks, LongestTimeBetweenBarks));
    }
}
