using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int waveNumber = 5;
    public int enemiesRemaining = 0;
    public GameObject[] enemyType;
    private int spawnPosX = 1;
    private int spawnPosZ = 1;
    private int spawnPosY = 1;
    private GameObject enemyToSpawn;

    public GameObject[] spawnLocations;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnWave();

    }

    void SpawnWave()
    {
        enemiesRemaining = GameObject.FindGameObjectsWithTag("Enemy").Length;

        //Vector3 spawnPos = new Vector3(Random.Range(-spawnPosX, spawnPosX), spawnPosY, Random.Range(spawnLocations[0].transform.localPosition.z, -spawnPosZ));
        //Vector3 spawnPos2 = new Vector3(Random.Range(-spawnPosX, spawnPosX), spawnPosY, Random.Range(spawnLocations[1].gameObject.transform.localPosition.z, -spawnPosZ));
        //Vector3 spawnPos3 = new Vector3(Random.Range(-spawnPosX, spawnPosX), spawnPosY, Random.Range(spawnLocations[2].gameObject.transform.localPosition.z, -spawnPosZ));

        if (enemiesRemaining == 0)
        {
            waveNumber += 1;
            for (int i = 0; i < waveNumber; i++)
            {
                if (i % 3 == 0)
                {
                    SpawnEnemy(-10);
                }
                else if (i % 3 == 1)
                {
                    SpawnEnemy(0);
                }
                else
                {
                    SpawnEnemy(10);

                }
            }
        }

    }

    void SpawnEnemy(int spawnLocation)
    {
        enemyToSpawn = enemyType[Random.Range(0, enemyType.Length)];
        Vector3 spawnPos = new Vector3(Random.Range(-spawnPosX, spawnPosX) + spawnLocation, spawnPosY, Random.Range(gameObject.transform.localPosition.z, -spawnPosZ));
        Instantiate(enemyToSpawn, spawnPos, transform.rotation);
    }

    
}
