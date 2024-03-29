using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTicker : MonoBehaviour
{
    State state = State.Work;
    int fps = 60;
    float boost = 1f;
    public int MaxFPS { get { return fps; } 
        set 
        {
            Debug.Log(value);
            if (value <= 0)
                fps = 1;
            MaxTickTime = (float)1 / fps; 
            fps = value;
            boost = (float)fps / 60;
        } 
    }
    float time = 0;
    public float MaxTickTime = 0.02f;

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
    public delegate void TimeTickerDelegate(float value);
    public event Action Stop;
    public event TimeTickerDelegate Tickk;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            MaxFPS += 10;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            MaxFPS -= 10;
        if (Input.GetKeyDown(KeyCode.Escape))
            if (state == State.Pause)
                state = State.Work;
            else
            {
                state = State.Pause;
                Stop?.Invoke();
            }
        if (state == State.Pause)
            return;
        time += Time.deltaTime;
        if (time > MaxTickTime)
        {
            while (time > MaxTickTime) 
            {
                Tickk?.Invoke(boost);
                time -= MaxTickTime;
            }
        }
    }
    [ContextMenu("MyMethod")]
    public void As()
    {
        Debug.Log("�");
    }
}
