using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> EnemiesToSpawn = new List<GameObject>();

    [SerializeField]
    GameObject Boss;

    [SerializeField]
    float spawnStartTime, spawnRepeatRate;

    [SerializeField]
    List<Transform> SpawnPoints = new List<Transform>();
    [SerializeField]
    Transform BossSpawnPoint;

    [SerializeField]
    List<GameObject> AllEnemies; // don't have to see it but good for debuging

    [SerializeField]
    int EnemyWaves, EnemySpawnPrWave;

    bool BossSpawned = false;

    [SerializeField]
    GameObject WinText;

    private void Start()
    {
        AllEnemies = new List<GameObject>();
        //InvokeRepeating("SpawnEnemies", spawnStartTime, spawnRepeatRate); // this will repeat for ever
        SpawnEnemies();
    }

    public void RemoveEnemy(GameObject enemy)
    {
        AllEnemies.Remove(enemy);
        CheckEnemyCount();
    }

    void CheckEnemyCount()
    {
        if (BossSpawned)
        {
            WinText.SetActive(true);
            return;
        }

        if (AllEnemies.Count == 0 && EnemyWaves <= 0)
        {
            Invoke("SpawnBoss", 3);
        }
    }

    void SpawnBoss()
    {
        BossSpawned = true;
        Instantiate(Boss, BossSpawnPoint.transform.position, Quaternion.identity);
    }

    void SpawnEnemies()
    {
        if (EnemyWaves <= 0)
        {
            CancelInvoke();
            return;
        }
        EnemyWaves--;
        Invoke("SpawnEnemies", spawnRepeatRate);
        SpawnEnemy(EnemySpawnPrWave);
    }

    void SpawnEnemy(int enemiesToSpawn = 1)
    {
        int chance;
        int spawnPoint;
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            chance = Random.Range(0, 2);
            spawnPoint = Random.Range(0, SpawnPoints.Count);
            var pos = Random.insideUnitCircle * 0.2f;
            Vector2 v2Point = new Vector2(SpawnPoints[spawnPoint].transform.position.x, SpawnPoints[spawnPoint].transform.position.y);
            AllEnemies.Add(Instantiate(EnemiesToSpawn[chance], pos + v2Point, Quaternion.identity));
        }
    }
}
