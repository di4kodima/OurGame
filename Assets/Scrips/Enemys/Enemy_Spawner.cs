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
    List<(Enemys, float)> CurrentWave;

    public void spawnWave(List<(Enemys, float)> EnemysWave) {
        CurrentWave = EnemysWave;
        delay = CurrentWave[0].Item2;
    }
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
                Enemys part = CurrentWave[0].Item1;

                CurrentWave.RemoveAt(0);
                delay = CurrentWave[0].Item2;

                GameObject Enemy = Resources.Load<GameObject>($"Prefabs/Enemies/{part.ToString()}");

                Debug.Log(Enemy.ToString() + $"{part.ToString()}объект");

                Enemy.GetComponent<Enemy_Goblin>().WayPoint = transform.parent.transform.parent.transform.GetChild(1).transform.GetChild(0).GetComponent<WayPointRandom>();

                Debug.Log("OOOOOOOOOOOOO");
                GameObject instantiatedObject = Instantiate(Enemy, transform.position, new Quaternion());
            }
        }
    }
}
