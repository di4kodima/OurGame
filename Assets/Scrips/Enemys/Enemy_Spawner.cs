using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public bool isWorking = false;

    public float delay;
    float timer = 0;

    private List<(Enemys, float)> CurrentWave;

    public void spawnWave(List<(Enemys, float)> EnemysWave) {
        isWorking = true;
        CurrentWave = EnemysWave;
        delay = CurrentWave[0].Item2;
    }



    // Start is called before the first frame update
    void Start()
    {

    }



    void Update()
    {
        if (!isWorking) return;
        if (CurrentWave.Count == 0) { isWorking = false; return; }

        timer += Time.deltaTime;
        if (timer >= delay)
        {
            timer = 0;

            string Enemy_type = CurrentWave[0].Item1.ToString();
            GameObject Enemy = Resources.Load<GameObject>($"Prefabs/Enemies/{Enemy_type}");
            CurrentWave.RemoveAt(0);
            delay = CurrentWave[0].Item2;
            Enemy.GetComponent<Enemy>().WayPoint = transform.parent.transform.parent.transform.GetChild(1).transform.GetChild(0).GetComponent<WayPointRandom>();
            GameObject instantiatedObject = Instantiate(Enemy, transform.position, new Quaternion());
        }
    }
}