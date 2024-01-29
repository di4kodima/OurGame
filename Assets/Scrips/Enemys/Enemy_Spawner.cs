using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public float delay = 5;
    float timer = 0;
    List<(Enemys, float)> CurrentWave;

    public void spawnWave(List<(Enemys, float)> EnemysWave) {
        CurrentWave = EnemysWave;
        delay = CurrentWave[0].Item2;
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
            timer = 0;
            if (CurrentWave.Count > 0)
            {
                string part = CurrentWave[0].Item1.ToString();

                GameObject Enemy = Resources.Load<GameObject>($"Prefabs/Enemies/{part}");
                CurrentWave.RemoveAt(0);
                delay = CurrentWave[0].Item2;
                Debug.Log(Enemy.ToString() + "������");

                Enemy.GetComponent<Enemy_Goblin>().WayPoint = transform.parent.transform.parent.transform.GetChild(1).transform.GetChild(0).GetComponent<WayPointRandom>();
                Debug.Log(Enemy.GetComponent<Enemy_Goblin>().WayPoint);
                GameObject instantiatedObject = Instantiate(Enemy, transform.position, new Quaternion());
            }
        }
    }
}