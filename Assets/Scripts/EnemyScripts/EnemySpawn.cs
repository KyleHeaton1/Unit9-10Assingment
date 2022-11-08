using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public float baseTime;
    float timer;

    void Start(){timer = baseTime;}
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            SpawnEnemy();
            timer = baseTime;
        }
    }

    void SpawnEnemy()
    {
        Vector3 pos = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
        Instantiate(enemy, pos, Quaternion.identity);
    }
}
