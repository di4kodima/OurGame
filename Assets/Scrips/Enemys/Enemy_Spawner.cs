using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy_Spawner : MonoBehaviour
{

    public void spawnWave((string, float)[] EnemysWave) {
        float Delay = 0;
        foreach ((string Enemy, float delay) in EnemysWave)
        {
            Delay += delay * 1000;
            spawnEnemy(Enemy, Delay);
        }
    }


    private void spawnEnemy(string Enemy, float delay) {
        GameObject prefabObject = Resources.Load<GameObject>($"Prefabs/Enemies/{Enemy}");
        prefabObject.GetComponent<Enemy_Goblin>().WayPoint = transform.parent.transform.parent.transform.GetChild(1).transform.GetChild(0).GetComponent<WayPointRandom>();

        GameObject instantiatedObject = Instantiate(prefabObject, transform.position, new Quaternion());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
