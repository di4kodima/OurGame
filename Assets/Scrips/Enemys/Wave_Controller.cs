using System.Collections.Generic;
using UnityEngine;


public class Wave_Controller : MonoBehaviour
{
    public List<(Enemys, float)> wave_1 = new List<(Enemys, float)>{ (Enemys.Goblin, 1), (Enemys.Ogr, 5), (Enemys.Ogr, 10), (Enemys.Goblin, 0.1f), (Enemys.Goblin, 0.1f), (Enemys.Ogr, 10), (Enemys.Goblin, 0.1f) };
    
    // Start is called before the first frame update
    void Start()
    {
        Enemy_Spawner enemy_Spawner = transform.GetChild(0).GetComponent<Enemy_Spawner>();
        enemy_Spawner.spawnWave(wave_1);
    }



    void Update()
    {
        
    }
}
