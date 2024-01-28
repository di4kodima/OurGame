using System.Collections.Generic;
using UnityEngine;

public class Wave_Controller : MonoBehaviour
{
    public List<(string, float)> wave_1 = new List<(string, float)>{ ("Goblin", 1), ("Goblin", 1), ("Goblin", 1), ("Goblin", 1), };
    private Enemy_Spawner enemy_Spawner;



    private void Awake()
    {
        transform.GetChild(0).GetComponent<Enemy_Spawner>();
    }



    void Start()
    {
        Enemy_Spawner enemy_Spawner = transform.GetChild(0).GetComponent<Enemy_Spawner>();
        enemy_Spawner.spawnWave(wave_1);
    }



    void Update()
    {
        
    }
}
