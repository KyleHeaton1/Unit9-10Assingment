using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;

    public ScoreManager scoreManager;
    GameObject scoreManagerObject;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        scoreManagerObject = GameObject.Find("ScoreManager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            scoreManager.score += 1;
            Destroy(gameObject);
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
