using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy_Spawner : MonoBehaviour
{
    public float delay = 1;
    float timer = 0;
    List<(string, float)> CurrentWave;

    public void spawnWave(List<(string, float)> EnemysWave) {
        CurrentWave = EnemysWave;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            Debug.Log("SDSD");
            timer = 0;
            if (CurrentWave.Count > 0)
            {
                string part = CurrentWave[0].Item1;

                GameObject Enemy = Resources.Load<GameObject>($"Prefabs/Enemies/{part}");

                Debug.Log(Enemy.ToString() + "объект");

                Enemy.GetComponent<Enemy_Goblin>().WayPoint = transform.parent.transform.parent.transform.GetChild(1).transform.GetChild(0).GetComponent<WayPointRandom>();

                Debug.Log("OOOOOOOOOOOOO");
                GameObject instantiatedObject = Instantiate(Enemy, transform.position, new Quaternion());
            }
        }
    }
}
