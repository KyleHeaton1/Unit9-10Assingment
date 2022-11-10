using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.timer = enemy.baseTime;
        enemy.anim.SetBool("isAttack", false);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        enemy.timer -= Time.deltaTime;

        if(enemy.timer <= 0)
        {
            enemy.SwitchState(enemy.AttackState);
        }
    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision collsion)
    {

    }
}
