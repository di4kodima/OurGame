using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTicker : MonoBehaviour
{
    private static TimeTicker instance;
    public static TimeTicker Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TimeTicker>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<TimeTicker>();
                    singletonObject.name = "MySingleton";
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }
    float time = 0;
    public float MaxTickTime = 0.02f;
    int tick = 0;

    public event Action Tickk;
    void Update()
    {
        time += Time.deltaTime;
        if (time > MaxTickTime)
        {
            Tickk?.Invoke();
            time -= MaxTickTime;
            tick++;
        }
    }
}
