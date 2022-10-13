using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<Waves> enemyWaves = new List<Waves>();

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    private int enemiesKilled = 0;

    private int currentWave = 0;

    public UnityEvent OnWinning;

 

    public void SpawnWave(int index)
    {
        if (index >= enemyWaves.Count)
            return;
        currentWave = index;
        StartCoroutine(SpawanWaveRoutine(index));
    }

    private IEnumerator SpawanWaveRoutine(int index)
    {
        Debug.Log("<<<<< Wave " + index + " is spawing " + enemyWaves[index].Wavename);

        List<GameObject> enemiesForThisWave = enemyWaves[index].enemies;

        foreach (var enemy in enemiesForThisWave)
        {
            var currentEnemy = GameObject.Instantiate(enemy);
            currentEnemy.GetComponent<EnemyHealth>().OnDied += EnemyDied;
            float maxHeath = currentEnemy.GetComponent<EnemyHealth>().OnEnemyDied;
            spawnedEnemies.Add(currentEnemy);
            yield return new WaitForSeconds(enemyWaves[index].spawnTime);
        }
    }

    private void EnemyDied(float value)
    {
        enemiesKilled++;
        if( enemiesKilled == enemyWaves[currentWave].enemies.Count)
        {
            if (currentWave == enemyWaves.Count - 1)
            {
                Debug.Log("<<<< You have WON");
                OnWinning.Invoke();
            }
            else
            {
                enemiesKilled = 0;
                SpawnWave(++currentWave);
            }
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            SpawnWave(0);
    }
}
