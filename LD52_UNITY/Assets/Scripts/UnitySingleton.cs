using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitySingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError($"There is another {typeof(T)} in the scene");
            Destroy(gameObject);
            return;
        }
        _instance = this as T;
    }
}
