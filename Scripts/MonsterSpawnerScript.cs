using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnerScript : MonoBehaviour
{
    float maxSpawnRateInSeconds = 5f;
    public GameObject[] objectsToInstantiate;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke ("SpawnMonster", maxSpawnRateInSeconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnMonster()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0,0)); 
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1)); 

        int n = Random.Range (0,5);
        GameObject monster = Instantiate (objectsToInstantiate[n]);
        monster.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);

        ScheduleNextMonsterSpawn ();
    }

    void ScheduleNextMonsterSpawn ()
    {
        float spawnInNSeconds;
        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else 
            spawnInNSeconds = 1f;
        Invoke ("SpawnMonster", spawnInNSeconds);
    }

    public void ScheduleMonsterSpawner ()
    {
        Invoke ("SpawnMonster", maxSpawnRateInSeconds);
    }


}
