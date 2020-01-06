using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 5; //number of blocks spawned per second
    float halfSpawnRange;
    public Transform fallingBlock;
    public GameObject blockPrefab;

    // Start is called before the first frame update
    void Start()
    {
        float screenWidth = Camera.main.aspect * Camera.main.orthographicSize;
        float blockWidth = fallingBlock.localScale.x;
        halfSpawnRange = (screenWidth - blockWidth) / 2f;
    }

    void FixedUpdate()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-halfSpawnRange, halfSpawnRange), transform.position.y, 0);
        Vector3 randomSpawnRotation = new Vector3(0,0, Random.Range(0,360));
        GameObject newBlock = (GameObject) Instantiate(blockPrefab, randomSpawnPosition, Quaternion.Euler(randomSpawnRotation));
        newBlock.transform.parent = transform;
    }
}
