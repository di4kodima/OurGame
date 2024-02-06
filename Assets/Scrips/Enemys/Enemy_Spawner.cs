using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public bool isWorking = false;

    private float delay;

    private List<(Enemys, float)> CurrentWave;

    /// <summary>
    /// Метод старта спавна волны. Задает все начальные параметры для спавна, после вызывает рекурсивнцю функцию Enemy_Spawner.SpawnWave()
    /// </summary>
    /// <param name="EnemysWave">Волна для спавна.</param>
    public void StartSpawnWave(List<(Enemys, float)> EnemysWave) {
        isWorking = true;
        CurrentWave = EnemysWave;
        delay = CurrentWave[0].Item2;
        StartCoroutine(SpawnWave());
    }

    /// <summary>
    /// Рекурсивная функция для спавна волны противников, оснаванная на корутине.
    /// </summary>
    /// <returns>Необходимый для корутины IEnumerator</returns>
    public IEnumerator SpawnWave()
    {
        if (!isWorking) yield return null;
        if (CurrentWave.Count == 0) { 
            isWorking = false;

            Debug.Log("Волна закончилась!");

            yield return null;
        }

        yield return new WaitForSeconds(delay);

        string Enemy_type = CurrentWave[0].Item1.ToString();
        GameObject Enemy = Resources.Load<GameObject>($"Prefabs/Enemies/{Enemy_type}");
        delay = CurrentWave[0].Item2;
        Enemy.GetComponent<Enemy>().WayPoint = GameObject.FindGameObjectWithTag("WayPointContainer").transform.GetChild(0).GetComponent<WayPointRandom>();
        GameObject instantiatedObject = Instantiate(Enemy, transform.position, new Quaternion());
        CurrentWave.RemoveAt(0);

        StartCoroutine(SpawnWave());
    }
}