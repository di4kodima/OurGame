using System.Collections.Generic;
using UnityEngine;


public class Wave_Controller : MonoBehaviour
{
    public List<(Enemys, float)> wave_1 = new List<(Enemys, float)>{ (Enemys.Goblin, 1), (Enemys.Goblin, 5f), (Enemys.Goblin, 5f), (Enemys.Goblin, 5f), (Enemys.Goblin, 1), (Enemys.Goblin, 5f), (Enemys.Goblin, 5f), (Enemys.Goblin, 5f), (Enemys.Goblin, 1), (Enemys.Goblin, 5f), (Enemys.Goblin, 5f), (Enemys.Goblin, 5f) };
    
    // Start is called before the first frame update
    void Start()
    {
        Enemy_Spawner enemy_Spawner = transform.GetChild(0).GetComponent<Enemy_Spawner>();
        enemy_Spawner.StartSpawnWave(wave_1);
    }



    void Update()
    {
        
    }
}
