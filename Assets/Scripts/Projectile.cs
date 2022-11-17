using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float timer; 
    public GameObject thePlayerCollision;
    public PlayerManager playerManager;
    public EnemyStateManager enemy;
    public int damage;

    void Start()
    {
        thePlayerCollision  = GameObject.Find("PlayerManager");
        playerManager = thePlayerCollision.GetComponent<PlayerManager>();
    }
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            playerManager.HurtPlayer(damage);
            Destroy(gameObject);
        }
    }

}
