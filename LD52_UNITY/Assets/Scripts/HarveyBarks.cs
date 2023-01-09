using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarveyBarks : MonoBehaviour
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
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/HarveyBark", gameObject);
        Invoke("PlayBark", Random.Range(ShortestTimeBetweenBarks, LongestTimeBetweenBarks));
    }
}
