using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Wave_Controller : MonoBehaviour
{
    public List<(string, float)> wave_1 = new List<(string, float)>{ ("Goblin", 10), ("Goblin", 10), ("Goblin", 10), ("Goblin", 10), ("Goblin", 10), ("Goblin", 10), ("Goblin", 10), };
    // Start is called before the first frame update
    void Start()
    {
        Enemy_Spawner enemy_Spawner = transform.GetChild(0).GetComponent<Enemy_Spawner>();
        enemy_Spawner.spawnWave(wave_1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
