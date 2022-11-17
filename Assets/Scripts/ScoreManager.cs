using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;
    public EnemySpawn enemySpawner;

    void Update()
    {
        scoreText.text = ("Score: " + score);


        if(score >= 10)
        {
            enemySpawner.baseTime = 8;
        }

        if(score >= 25)
        {
            enemySpawner.baseTime = 5;
        }

        if(score >= 50)
        {
            enemySpawner.baseTime = 3;
        }
    }
}
