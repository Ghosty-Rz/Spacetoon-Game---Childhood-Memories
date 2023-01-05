using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject Enemy;
float maxSpawnRateInSeconds = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0,0)); 
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1)); 

        GameObject anEnemy = (GameObject)Instantiate (Enemy);
        anEnemy.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);

        ScheduleNextEnemySpawn ();
    }

    void ScheduleNextEnemySpawn ()
    {
        float spawnInNSeconds;
        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else 
            spawnInNSeconds = 1f;
        Invoke ("SpawnEnemy", spawnInNSeconds);
    }

    public void ScheduleEnemySpawner ()
    {
        Invoke ("SpawnEnemy", maxSpawnRateInSeconds);
    }
}
