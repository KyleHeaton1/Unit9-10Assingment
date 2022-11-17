using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;
    public TMP_Text healthText, ammoText;
    public GameObject deathScreen;
    public float timeAfterDeath = 3.25f;

    public ScoreManager scoreManager;

    public Animator doomGuy;

    public ARCursor ARcursorScript;
    public GameObject hurtScreen;

    float timer;
    float baseTime = .3f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        healthText.text = ("" + startingHealth + "%");
        ammoText.text = ("" + ARcursorScript.ammo);
        timer = baseTime;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = ("" + currentHealth + "%");
        ammoText.text = ("" + ARcursorScript.ammo);
        if(ARcursorScript.ammo <= 0)
        {
            ARcursorScript.canShoot = false;
            ARcursorScript.timer = 1;
        }

        if(currentHealth >= 50 && scoreManager.score > 2)
        {
            doomGuy.Play("reaction");
        }
        if(currentHealth <= 50)
        {
            doomGuy.Play("hurtIdle");
        }
        if (currentHealth <= 0)
        {
            doomGuy.Play("death");
            deathScreen.SetActive(true);
            Invoke("sceneLoad", timeAfterDeath);
        }

        timer -=Time.deltaTime;
        if(timer <= 0)
        {
            hurtScreen.SetActive(false);
            timer = baseTime;
        }
    }
    public void HurtPlayer(int damage)
    {
        timer = baseTime;
        currentHealth -= damage;
        hurtScreen.SetActive(true);
    }
    void sceneLoad()
    {
        SceneManager.LoadScene("SampleScene");
    }



    
}
