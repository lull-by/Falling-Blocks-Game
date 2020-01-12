using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    static Vector2 secondsBetweenSpawnsMinMax = new Vector2(0.15f,1f); //the min and max values of the secondsBetweenSpawns
    Vector2 halfScreenSize;
    public GameObject blockPrefab;
    float nextSpawnTime = 0;
    public float largestBlock = 3f;
    public float smallestBlock = 0.7f;
    public float spawnAngle = 10; //degrees away from perfectly vertical that a fallingBlock can spawn


    // Start is called before the first frame update
    void Start()
    {
        halfScreenSize = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    void FixedUpdate()
    {
        float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.getDifficultyPercent());
        //print(Difficulty.getDifficultyPercent());
        //print(secondsBetweenSpawns);
        
        if (Time.timeSinceLevelLoad > nextSpawnTime)
        {
            float spawnSize = Random.Range(smallestBlock, largestBlock);
            Vector2 spawnPosition = new Vector2(Random.Range(-halfScreenSize.x, halfScreenSize.x), halfScreenSize.y + spawnSize);
            Vector3 spawnRotation = new Vector3(0,0,1) * Random.Range(-spawnAngle,spawnAngle);
            
            //Instantiate(blockPrefab, randomSpawnPosition, Quaternion.Euler(randomSpawnRotation));
            GameObject newBlock = (GameObject) Instantiate(blockPrefab, spawnPosition, Quaternion.Euler(spawnRotation));
            //newBlock.transform.parent = transform;

            newBlock.transform.localScale = Vector2.one * spawnSize;
            nextSpawnTime += secondsBetweenSpawns;
        }
    }
}
