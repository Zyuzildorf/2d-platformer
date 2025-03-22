using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimationsSetter : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void RestartWalkAnimation()
    {
        _animator.SetBool(EnemyAnimatorData.Params.IsWalking, true);
    }

    public void StopWalkAnimation()
    {
        _animator.SetBool(EnemyAnimatorData.Params.IsWalking, false);
    }
}