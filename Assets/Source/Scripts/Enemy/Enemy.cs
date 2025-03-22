using UnityEngine;

[RequireComponent(typeof(EnemyPatrol), typeof(EnemyAnimationsSetter))]
public class Enemy : MonoBehaviour
{
    private EnemyAnimationsSetter _enemyAnimationsSetter;
    private EnemyPatrol _enemyPatrol;
    private bool _isPatrolling;

    private void Awake()
    {
        _enemyAnimationsSetter = GetComponent<EnemyAnimationsSetter>();
        _enemyPatrol = GetComponent<EnemyPatrol>();
        _isPatrolling = true;
    }

    private void Update()
    {
        if (_isPatrolling)
        {
            _enemyPatrol.Patrol();

            if (_enemyPatrol.IsTargetReached == false)
            {
                _enemyAnimationsSetter.RestartWalkAnimation();
            }
            else
            {
                _enemyAnimationsSetter.StopWalkAnimation();
            }
        }
    }
}