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

    public ARCursor ARcursorScript;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        healthText.text = ("" + startingHealth + "%");
        ammoText.text = ("" + ARcursorScript.ammo);
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

        if (currentHealth <= 0)
        {
            deathScreen.SetActive(true);
            Invoke("sceneLoad", timeAfterDeath);
        }
    }

    void sceneLoad()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
