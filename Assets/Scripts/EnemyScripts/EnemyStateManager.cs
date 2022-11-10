using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{

    public float timer; 
    public float baseTime;
    public GameObject projectile; 
    public GameObject thePlayer;

    public Animator anim;

    public GameObject firePoint;

    EnemyBaseState currentState;
    public EnemyIdleState IdleState = new EnemyIdleState();
    public EnemyAttackState AttackState = new EnemyAttackState();


    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.Find("PlayerManager");
        currentState = IdleState;
        currentState.EnterState(this);
    }
    void LateUpdate() 
    {
        transform.LookAt(thePlayer.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    void OnCollisionEnter(Collision collsion)
    {
        currentState.OnCollisionEnter(this, collsion);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void Shoot()
    {
        GameObject plasma = Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        Rigidbody plasmaBody = plasma.GetComponent<Rigidbody>();
        plasmaBody.velocity = transform.forward * 10;
    }
}
