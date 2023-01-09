using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBarks : MonoBehaviour
{
    [SerializeField] float ShortestTimeBetweenBarks = 4f;
    [SerializeField] float LongestTimeBetweenBarks = 9f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("PlayBark", Random.Range(ShortestTimeBetweenBarks, LongestTimeBetweenBarks));
    }

    void PlayBark()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Squeak", gameObject);
        Invoke("PlayBark", Random.Range(ShortestTimeBetweenBarks, LongestTimeBetweenBarks));
    }
}
