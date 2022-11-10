using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.Shoot();
        enemy.anim.SetBool("isAttack", true);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        enemy.SwitchState(enemy.IdleState);
    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision collsion)
    {

    }
}