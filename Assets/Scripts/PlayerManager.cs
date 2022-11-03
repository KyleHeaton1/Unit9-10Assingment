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
    public TMP_Text Text;
    public GameObject deathScreen;
    public float timeAfterDeath = 1f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        Text.text = ("" + startingHealth + "%");
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = ("" + currentHealth + "%");

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
